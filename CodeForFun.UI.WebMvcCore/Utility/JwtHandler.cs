using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CodeForFun.UI.WebMvcCore.Utility
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        private readonly JwtOptions _options;
        private readonly SecurityKey _issuerSigningKey;
        private readonly SigningCredentials _signingCredentials;
        private readonly JwtHeader _jwtHeader;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly IConfiguration _config;

        public JwtHandler(IOptions<JwtOptions> options, IConfiguration config)
        {
            _options = options.Value;
            _config = config;
            _issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            _signingCredentials = new SigningCredentials(_issuerSigningKey, SecurityAlgorithms.HmacSha256);
            _jwtHeader = new JwtHeader(_signingCredentials);
            _tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateAudience = false,
                ValidIssuer = _options.Issuer,
                IssuerSigningKey = _issuerSigningKey
            };
            _options = new JwtOptions()
            {
                Issuer = _config.GetSection("AppSettings:issuer").Value,

                ExpiryMinutes = Convert.ToInt32(_config.GetSection("AppSettings:expiryMinutes").Value)
            };
        }

        public JsonWebToken Create(Guid userId, string role, string name)
        {
            try
            {
                var nowUtc = DateTime.UtcNow;
                var expires = nowUtc.AddDays(_options.ExpiryMinutes);
                var centuryBegin = new DateTime(1970, 1, 1).ToUniversalTime();
                var exp = (long)(new TimeSpan(expires.Ticks - centuryBegin.Ticks).TotalSeconds);
                var now = (long)(new TimeSpan(nowUtc.Ticks - centuryBegin.Ticks).TotalSeconds);

                var claims = new Claim[]
                        {
                    new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                    new Claim("fullName", name),
                    new Claim("role", role),
                    new Claim(JwtRegisteredClaimNames.Iat, now.ToString()),
                    new Claim(JwtRegisteredClaimNames.Exp, exp.ToString()),
                    new Claim(JwtRegisteredClaimNames.Iss, _options.Issuer),
                    new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                        };

                //var payLoad = new JwtPayload()
                //{
                //    {"sub", userId },
                //    {"iss", _options.Issuer },
                //    {"iat", now },
                //    {"exp", exp },
                //    {"unique_name", email }
                //};
                var jwt = new JwtSecurityToken(
                        issuer: _options.Issuer,
                        claims: claims,
                        signingCredentials: _signingCredentials
                        );
                // var jwt = new JwtSecurityToken(_jwtHeader, payLoad);
                var token = _jwtSecurityTokenHandler.WriteToken(jwt);
                return new JsonWebToken()
                {
                    Token = token,
                    Expires = exp
                };
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
