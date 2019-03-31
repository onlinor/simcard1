﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using SimCard.APP.Models;
using SimCard.APP.Persistence.Repositories;
using SimCard.APP.ViewModels;

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SimCard.APP.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly AppSettings _appSettings;


        public AuthService(IUserRepository userRepository, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _userRepository = userRepository;
        }

        public async Task<UserViewModel> Authenticate(LoginViewModel loginViewModel)
        {
            User user = await _userRepository.Query(x => x.Username == loginViewModel.Username).FirstOrDefaultAsync();

            // return null if user not found
            if (user == null)
            {
                return null;
            }
            var isValidPassword = PasswordHelper.ValidatePassword(loginViewModel.Password, user.Password, user.PasswordSalt);

            if (!isValidPassword)
            {
                return null;
            }

            // authentication successful so generate jwt token
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            UserViewModel result = new UserViewModel
            {
                Username = user.Username,
                Token = tokenHandler.WriteToken(token)
            };
            return result;
        }
    }
}
