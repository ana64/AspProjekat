using AspMovie.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace AspMovie.Api.Core
{
    public class JwtManager
    {
        private readonly JwtSettings settings;
        private readonly ProjectDbContext context;
       

        public JwtManager(JwtSettings settings, ProjectDbContext context)
        {
            this.settings = settings;
            this.context = context;
        }

      

        public string MakeToken(string email,string password)
        {
            var user = context.Users.Include(x => x.UseCases).FirstOrDefault(x => x.Email == email);

            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }

            var valid = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (!valid)
            {
                throw new UnauthorizedAccessException();
            }

           // var useCases = context.UserUseCase.Where(x => x.UserId == user.UserId).Select(x => x.UseCaseId);

            var actor = new JwtUser
            {
                Id = user.Id,
                UseCaseIds = user.UseCases.Select(x => x.UseCaseId).ToList(),
                Identity = user.Email,
                Email = user.Email
            };

            var claims = new List<Claim> // Jti : "",
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iss, settings.Issuer),
                new Claim(JwtRegisteredClaimNames.Iat, 
                          DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(),
                          ClaimValueTypes.Integer64, 
                          settings.Issuer),
                new Claim("UserId", actor.Id.ToString(), ClaimValueTypes.String, settings.Issuer),
                new Claim("UseCases", JsonConvert.SerializeObject(actor.UseCaseIds)),
                new Claim("Email", user.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.SecretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: settings.Issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(settings.Minutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
