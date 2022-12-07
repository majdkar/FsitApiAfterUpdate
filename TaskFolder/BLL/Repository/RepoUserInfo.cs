using BLL.Context;
using DL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace BLL.Repository
{
   public class RepoUserInfo : RepositoryGeneric<UserInfo>
    {
        public IConfiguration _configuration;
        private readonly ApplicationContext _context;

        public RepoUserInfo(IConfiguration configuration ,ApplicationContext context) : base(context)
        {
            _configuration = configuration;
            _context = context;
        }

        public void Register(UserInfo u)
        {
            var adduser = new UserInfo()
            {
                UserName = u.UserName,
                Password = BC.HashPassword(u.Password),
                Email = u.Email,
            };
           
            _context.TblUsers.Add(adduser);
           _context.SaveChanges();
        }

        public void UpdateUserById(int id, UserInfo u)
        {
            var _user = _context.TblUsers.FirstOrDefault(p => p.Id == id);
            if (_user != null)
            {
                _user.UserName = u.UserName;
                _user.Password = u.Password;
                _user.Email = u.Email;
                _user.Id = id;

                _context.TblUsers.Update(_user);
                _context.SaveChanges();
            }

        }

        public async Task<string> LoginUser(UserInfo users)
        {
            if (users != null && users.Password != null && users.Email != null)
            {
                var user = await CheckUser(users.Email, users.Password);
                if (user != null)
                {
                    var claims = new[]
                    {
                      new Claim(JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                        new Claim("Id" , user.Id.ToString()),
                        new Claim("UserName" , user.UserName),
                        new Claim("Email" , user.Email),
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"]
                        , expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    var tokencode = new JwtSecurityTokenHandler().WriteToken(token);
                    return tokencode;
                }
                else
                {
                    return "Invalid Email And Passwrod";
                }

            }
            else
            {
                return "Invalid Email And Passwrod";
            }
        }

        private async Task<UserInfo> CheckUser(string email, string password)
        {
            var user = await _context.TblUsers.FirstOrDefaultAsync(x => x.Email == email);

            if (user != null && BC.Verify(password, user.Password))
            {
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
