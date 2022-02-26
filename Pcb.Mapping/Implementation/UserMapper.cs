using Pcb.Database.Context.Models;
using Pcb.Dto.School;
using Pcb.Dto.Security;
using Pcb.Dto.User;
using Pcb.Mapping.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace Pcb.Mapping.Implementation
{
    public class UserMapper : IUserMapper
    {
        public User MapRegisterUserProfileDtoToUser(RegisterUserDto userDto)
        {
            if (userDto == null) { return null; }
            bool isSocial = userDto.LoginProvider.ToLower() == "google";
            return new User
            {
                Username = userDto.Email,
                FamilyName = userDto.LastName,
                GivenNames = userDto.FirstName,
                EmailAddress = userDto.Email,
                PasswordHash = (userDto.Password != null) ? BC.HashPassword(userDto.Password) : null,
                PhotoUrl = userDto.PhotoUrl,
                PhoneNumber = null,
                Verified = userDto.Verified,
                IsActive = true,
                IsStudent = false,
                LoginProvider = userDto.LoginProvider,
                LoginProviderId = userDto.LoginProviderId,
                FirstLogin = isSocial ? DateTime.UtcNow : new DateTime(),
                LastLogin = isSocial ? DateTime.UtcNow : new DateTime(),
                VerificationToken = isSocial ? null : RandomTokenString(),

                UserRole = NewUserRole(), // defaults to standard user account
                TimesLoggedIn = isSocial ? 1 : 0
            };
        }

        public RoleDto MapRoleToRoleDto(Role map)
        {
            if (map == null) { return null; }
            return new RoleDto
            {
                Id = map.Id,
                Title = map.Title,
                Summary = map.Summary,
                Rank = map.Rank,
                IsAdmin = map.IsAdmin,
                IsUser = map.IsUser
            };
        }

        public SchoolDto MapSchoolToSchoolDto(School map)
        {
            if (map == null) { return null; }
            return new SchoolDto
            {
                Id = map.Id,
                Title = map.Title,
                Code = map.Code,
                ShortName = map.ShortName,
                StartDate = map.StartDate,
                EndDate = map.EndDate,
                BusinessContactName = map.BusinessContactName,
                EmailAddress = map.EmailAddress,
                StreetNumber = map.StreetNumber,
                Address = map.Address,
                Suburb = map.Suburb,
                PostCode = map.PostCode,
                PhoneNumber = map.PhoneNumber,
                CreatedAt = map.CreatedAt
            };
        }

        public List<UserRoleDto> MapUserRoleToUserRoleDto(IEnumerable<UserRole> map)
        {
            if (map == null) { return null; }
            List<UserRoleDto> convertList = new List<UserRoleDto>();
            foreach (var item in map.ToList())
            {
                convertList.Add(new UserRoleDto
                {
                    Id = item.Id,
                    UserId = item.UserId,
                    RoleId = item.RoleId,
                    SchoolId = item.SchoolId,
                    IsCountryWide = item.IsCountryWide,
                    School = MapSchoolToSchoolDto(item.School),
                    Role = MapRoleToRoleDto(item.Role)
                });
            }
            return convertList;
        }

        public UserProfileDto MapUserToUserProfileDto(User map)
        {
            if (map == null) { return null; }
            return new UserProfileDto
            {
                Id = map.Id,
                Email = map.EmailAddress,
                FullName = map.FullName,
                LastName = map.FamilyName,
                FirstName = map.GivenNames,
                PhotoUrl = map.PhotoUrl,
                IsVerified = map.IsVerified,
                IsStudent = (bool)map.IsStudent,
                IsActive = map.IsActive,
                LoginProvider = map.LoginProvider,
                LoginProviderId = map.LoginProviderId,
                TimesLoggedIn = map.TimesLoggedIn,
                FirstLogin = map.FirstLogin,
                LastLogin = map.LastLogin,
                CreatedAt = map.CreatedAt,
                UserRole = MapUserRoleToUserRoleDto(map.UserRole)
            };
        }
        private static List<UserRole> NewUserRole()
        {
            List<UserRole> newUserRole = new List<UserRole>
            {
                new UserRole
                {
                    RoleId = 2,
                    IsCountryWide = false
                }
            };
            return newUserRole;
        }

        private static string RandomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            // convert random bytes to hex string
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }
    }
}
