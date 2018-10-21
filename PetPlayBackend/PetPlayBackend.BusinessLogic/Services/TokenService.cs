using Microsoft.IdentityModel.Tokens;
using PetPlayBackend.BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PetPlayBackend.BusinessLogic.Services
{
    public class TokenService : ITokenService
    {
        private readonly Random _rnd;
        private readonly String _issuer;
        private readonly String _audience;
        private readonly Byte[] _key;
        private readonly Int32 _lifetime;

        public TokenService(String issuer, String audience, String key, Int32 lifetime)
        {
            _rnd = new Random();
            _issuer = issuer;
            _audience = audience;
            _key = Convert.FromBase64String(key);
            _lifetime = lifetime;
        }

        public String BuildToken(Guid id)
        {
            var key = new SymmetricSecurityKey(_key);
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jti = _rnd.Next().ToString("X08");

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, jti),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            };
            
            var token = new JwtSecurityToken(
                _issuer,
                _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_lifetime),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
