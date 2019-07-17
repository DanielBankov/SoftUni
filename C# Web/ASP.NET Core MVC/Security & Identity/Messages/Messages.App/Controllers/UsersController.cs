using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Messages.App.Jwt;
using Messages.App.Models;
using Messages.Data;
using Messages.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Messages.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly MessageDbContext context;

        private readonly JwtSettings jwtSettings;

        public UsersController(MessageDbContext context, IOptions<JwtSettings> jwtSettings)
        {
            this.context = context;
            this.jwtSettings = jwtSettings.Value;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody]UserBindingModel model)
        {
            this.context.Users.Add(new User
            {
                Username = model.Username,
                Password = model.Password
            });

            await this.context.SaveChangesAsync();
            return this.Ok();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]UserBindingModel model)
        {
            var dbUser = await this.context.Users.SingleOrDefaultAsync(user => user.Username == model.Username
                                                                            && user.Password == model.Password);

            if (dbUser == null)
            {
                return this.BadRequest("Username or password is invalid!");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, dbUser.Username)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return this.Ok(token);
        }
    }
}