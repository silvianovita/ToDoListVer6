using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Services.Interface;
using Data.Context;
using Data.Model;
using Data.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public IConfiguration _configuration;
        private readonly MyContext _context;
        public UsersController(IUserServices userServices, IConfiguration config, MyContext context)
        {
            _userServices = userServices;
            _configuration = config;
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _userServices.Get();
        }

        [HttpGet("{Id}")]
        public async Task<IEnumerable<User>> Get(int Id)
        {
            return await _userServices.Get(Id);
        }
        [HttpPost]
        public ActionResult Post(UserVM userVM)
        {
            return Ok(_userServices.Create(userVM));
        }
        [HttpPut("{Id}")]
        public ActionResult Put(int Id, UserVM userVM)
        {
            return Ok(_userServices.Update(Id, userVM));
        }
        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {
            return Ok(_userServices.Delete(Id));
        }
        //[HttpPost("{userVM}")]
        //public User Login(UserVM userVM)
        //{
        //    return _userServices.Login(userVM);
        //}
        [HttpPost]
        [Route("Login")]
        public ActionResult<User> Login(UserVM _userVM)
        {
            if (_userVM != null && _userVM.UserName != null && _userVM.Password != null)
            {
                var user = GetUser(_userVM);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", user.Id.ToString())
                   };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddMinutes(10), signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token) + "..." + user.Id);
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("{userVM}")]
        public User GetUser(UserVM userVM)
        {
            return _userServices.Login(userVM);
        }
    }
}