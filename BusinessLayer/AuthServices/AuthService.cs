using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.Common;
using ApplicationLayer.Models.InputModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using NuGet.Protocol.Plugins;

namespace BusinessLayer.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _config;
        private ApplicationUser ApplicationUser;
        private readonly RoleManager<IdentityRole> _roleManager;


        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration config, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            ApplicationUser = new();
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<IdentityError>> Register(Register register)
        {
            var newUser = new ApplicationUser
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                Email = register.Email,
                UserName = register.Email
            };

            var result = await _userManager.CreateAsync(newUser, register.Password);

            if (result.Succeeded && !string.IsNullOrWhiteSpace(register.Role))
            {
                if (!await _roleManager.RoleExistsAsync(register.Role))
                {
                    var roleResult = await _roleManager.CreateAsync(new IdentityRole(register.Role));
                    if (!roleResult.Succeeded)
                    {
                        return roleResult.Errors;
                    }
                }

                await _userManager.AddToRoleAsync(newUser, register.Role);
            }

            return result.Errors;
        }

        public async Task<object> Login(Login login)
        {
            ApplicationUser = await _userManager.FindByEmailAsync(login.Email);

            if (ApplicationUser == null)
            {
                return "Invalid Email Address";
            }

            var result = await _signInManager.PasswordSignInAsync(ApplicationUser, login.Password, isPersistent: false, lockoutOnFailure: true);
            var isValidCredential = await _userManager.CheckPasswordAsync(ApplicationUser, login.Password);

            if (result.Succeeded)
            {
                var token = await GenerateToken();

                LoginResponse loginResponse = new LoginResponse
                {
                    UserId = ApplicationUser.Id,
                    Token = token,
                    Email = ApplicationUser.UserName,
                    
                };

                return loginResponse;
            }
            else
            {
                if (result.IsLockedOut)
                {
                    return "Your Account is Locked,Contact System Admin";
                }

                if (result.IsNotAllowed)
                {
                    return "Please Verify Email Address";
                }

                if (isValidCredential == false)
                {
                    return "Invalid Password";
                }
                else
                {
                    return "Login Failed";
                }
            }
        }


        public async Task<string> GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));

            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(ApplicationUser);

            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();

            List<Claim> claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email,ApplicationUser.Email)
            }.Union(roleClaims).ToList();

            var token = new JwtSecurityToken
                (
                issuer: _config["JwtSettings:Issuer"],
                audience: _config["JwtSettings:Audience"],
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(_config["JwtSettings:DurationInMinutes"]))
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private class LoginResponse
        {
            public string UserId { get; set; }
            public string Token { get; set; }
            public string Email { get; set; }
        }
    }
}
