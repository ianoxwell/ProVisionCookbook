using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pcb.Configuration;
using Pcb.Database;
using Pcb.Database.Context;
using Pcb.Database.Context.Models;
using Pcb.Dto.Api;
using Pcb.Dto.Security.Accounts;
using Pcb.Dto.User;
using Pcb.Mapping.Interface;
using Pcb.Security;
using Pcb.Service.Interfaces;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace Pcb.Service.Implementations
{
    public class AccountService : ServiceBase<PcbDbContext>, IAccountService
    {
        private IUserMapper UserMapper { get; }
        private IPcbSecurityService SecurityService { get; }
        private IEmailService EmailService { get; }
        public AccountService(
            IUserMapper userMapper,
            IPcbSecurityService securityService,
            IEmailService emailService,
            IPcbConfiguration configurationService,
            ILogger<AccountService> logger)
            : base(configurationService, logger)
        {
            UserMapper = userMapper;
            SecurityService = securityService;
            EmailService = emailService;
        }
        public async Task<int> RegisterUser(RegisterUserDto userDto, string origin)
        {
            using var _db = GetReadWriteDbContext();
            var mapped = UserMapper.MapRegisterUserProfileDtoToUser(userDto);
            _db.User.Add(mapped);
            await _db.SaveChangesAsync();
            if (mapped.LoginProvider == "Local")
            {
                SendVerificationEmail(mapped, origin);
            }

            return mapped.Id;
        }

        public async Task<bool> VerifyEmail(string token)
        {
            using var _db = GetReadWriteDbContext();
            User account = await _db.User.SingleOrDefaultAsync(x => x.VerificationToken == token);

            if (account == null) { return false; }
            account.Verified = DateTime.UtcNow;
            account.VerificationToken = null;

            _db.User.Update(account);
            int result = _db.SaveChanges();
            return result != 0;
        }

        public async Task<MessageResultDto> ForgotPassword(ForgotPasswordRequest model, string origin)
        {
            if (model == null) { return new MessageResultDto { Message = "No email received" }; }
            using var _db = GetReadWriteDbContext();
            var account = await _db.User.SingleOrDefaultAsync(x => x.EmailAddress.ToLower() == model.Email.ToLower().Trim());

            if (account == null) { return new MessageResultDto { Message = $"No email address like {model.Email} has been found" }; }

            if (account.LoginProvider == "GOOGLE")
            {
                return new MessageResultDto { Message = "Please login through your Google Account" };
            }
            // create reset token that expires after 2 hour
            account.ResetToken = RandomTokenString();
            account.ResetTokenExpires = DateTime.UtcNow.AddHours(2);

            _db.User.Update(account);
            _db.SaveChanges();

            //send Email
            SendPasswordResetEmail(account, origin);
            return new MessageResultDto { Message = "Email sent" };

        }
        public async Task<bool> ValidateResetToken(VerifyTokenRequest model)
        {
            if (model == null) { return false; }
            using var _db = GetReadOnlyDbContext();
            var account = await _db.User.SingleOrDefaultAsync(x => x.ResetToken == model.Token && x.ResetTokenExpires > DateTime.UtcNow);
            return account != null;
        }
        public async Task<MessageResultDto> ResetPassword(ResetPasswordRequest model)
        {
            if (model == null)
            {
                return new MessageResultDto { Message = "No token or password received." };
            }
            using var _db = GetReadWriteDbContext();
            var account = await _db.User.SingleOrDefaultAsync(x => x.ResetToken == model.Token);
            if (account == null)
            {
                return new MessageResultDto { Message = $"No account with that token has been found." };
            }
            if (account.ResetTokenExpires < DateTime.UtcNow)
            {
                return new MessageResultDto { Message = "Reset Token has expired." };
            }
            // update password and remove reset token
            account.PasswordHash = BC.HashPassword(model.Password);
            account.PasswordReset = DateTime.UtcNow;
            account.ResetToken = null;
            account.ResetTokenExpires = null;
            account.LastFailedLoginAttempt = new DateTime();
            account.FailedLoginAttempt = 0;
            _db.User.Update(account);
            int result = _db.SaveChanges();
            return new MessageResultDto { Message = result != 0 ? "Success" : "Something went wrong" };
        }

        public bool UserNameExists(string name)
        {
            using var _db = GetReadOnlyDbContext();
            User value = _db.User.FirstOrDefault(a => a.EmailAddress.ToLower().Trim() == name.ToLower().Trim());
            return (value == null);
        }

        public async Task<UserProfileDto> GetSingleUser(int userId)
        {
            if (userId == 0) { return null; }

            string loggedInUserId = SecurityService.GetTokenUserIdValue();
            bool isParsable = int.TryParse(loggedInUserId, out int number);

            if (!isParsable && userId != number)
            {
                Logger.LogError($"Get Profile Error: User with logged in Id '{loggedInUserId}' attempted to get a users profile with a userId of '{userId}'.");
                throw new UnauthorizedAccessException();
            }
            using var _db = GetReadOnlyDbContext();
            var user = await _db.User.Where(u => u.Id == userId)
                .Include(x => x.UserRole).ThenInclude(y => y.Role)
                .Include(x => x.UserRole).ThenInclude(y => y.School)
                .SingleOrDefaultAsync();
            if (user == null) { return null; }
            return UserMapper.MapUserToUserProfileDto(user);
        }

        private static string RandomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            // convert random bytes to hex string
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }

        private void SendVerificationEmail(User account, string origin)
        {
            string message;
            if (!string.IsNullOrEmpty(origin))
            {
                var verifyUrl = $"{origin}/account/verify-email?token={account.VerificationToken}";
                message = $@"<p>Please click the below link to verify your email address:</p>
                             <p><a href=""{verifyUrl}"">{verifyUrl}</a></p>";
            }
            else
            {
                message = $@"<p>Please use the below token to verify your email address with the <code>/accounts/verify-email</code> api route:</p>
                             <p><code>{account.VerificationToken}</code></p>";
            }

            EmailService.Send(
                to: account.EmailAddress,
                subject: "Sign-up Verification API - Verify Email",
                html: "<h4>Verify Email</h4>\n" +
                        "<p>Thanks for registering with ProVision Cookbook!</p>\n</td>\n</tr>\n<tr>\n<td align=\"left\" valign=\"top\" class=\"content\">\n" + message
            );
        }

        private void SendPasswordResetEmail(User account, string origin)
        {
            string message;
            if (!string.IsNullOrEmpty(origin))
            {
                var resetUrl = $"{origin}/account/reset-password?token={account.ResetToken}";
                message = $@"<p>Please click the below link to reset your password, the link will be valid for 1 day:</p>
                             <p><a href=""{resetUrl}"">{resetUrl}</a></p>";
            }
            else
            {
                message = $@"<p>Please use the below token to reset your password with the <code>/accounts/reset-password</code> api route:</p>
                             <p><code>{account.ResetToken}</code></p>";
            }

            EmailService.Send(
                to: account.EmailAddress,
                subject: "Sign-up Verification API - Reset Password",
                html: "<h4>Reset Password Email</h4>\n</td>\n</tr>\n<tr>\n<td align=\"left\" valign=\"top\" class=\"content\">\n" +
                         $"{message}"
            );
        }
    }
}
