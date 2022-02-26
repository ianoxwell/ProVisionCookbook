using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Pcb.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Pcb.Api.Auth
{
    /// <inheritdoc />
    public class JwtFactory : IJwtFactory
    {
        /// <summary>
        /// The Pcb configuration instance
        /// </summary>
        private readonly IPcbConfiguration Config;

        /// <summary>
        /// JWT Factory Interface contructor.
        /// </summary>
        /// <param name="configuration">The Cpt configuration instance.</param>
        public JwtFactory(IPcbConfiguration configuration)
        {
            Config = configuration;
        }

        /// <inheritdoc />
        public string GenerateToken(IEnumerable<Claim> claims)
        {
            var audience = Config.PcbAppSettings.SecuritySettings.JwtIssuerOptions.Audience;
            var issuer = Config.PcbAppSettings.SecuritySettings.JwtIssuerOptions.Issuer;
            var startDate = DateTime.Now.ToUniversalTime();
            var endDate = DateTime.Now.AddMinutes(Config.PcbAppSettings.DataSettings.JwtLifetime).ToUniversalTime();

            var secureKey = Config.PcbAppSettings.SecuritySettings.JwtIssuerOptions.Key;
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secureKey));
            var signingCredential = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtHeader = new JwtHeader(signingCredential);
            var jwtPayload = new JwtPayload(issuer, audience, claims, startDate, endDate, startDate);
            var token = new JwtSecurityToken(jwtHeader, jwtPayload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
