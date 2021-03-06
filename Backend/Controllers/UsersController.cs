using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SavingsDeposits.DTOs;
using SavingsDeposits.Helpers;
using SavingsDeposits.Entities;
using SavingsDeposits.Services;

namespace SavingsDeposits.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private readonly UserManager<User> _userManager;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UsersController(
            IMapper mapper,
            IOptions<AppSettings> appSettings,
            IUserService userService, UserManager<User> userManager)
        {
            _userService = userService;
            _userManager = userManager;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]UserDto userDto)
        {
            User user = await _userService.Authenticate(userDto.Username, userDto.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var roles = await _userManager.GetRolesAsync(user);
            string mainRole = roles.FirstOrDefault();
            if (mainRole == null)
            {
                throw new AppException("User doesn't have a role");
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, user.Id),
                    new Claim(ClaimTypes.Role, mainRole)
                }),
                Expires = DateTime.UtcNow.AddSeconds(_appSettings.TokenExpiry)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new{user.UserName,tokenString, role = mainRole});
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var info = await _userService.CreateAsync(user, userDto.Password);
          
            if(info.Succeeded)
            {
                return Ok();
            } 
            else
            {
                return BadRequest(new { message = info.Errors.First().Description });
            }
        }

        [HttpGet]
        [Authorize(Roles="Admin,Manager")]
        public async Task<IActionResult> GetAllAsync()
        {
            var users =  await _userService.GetAllAsync();
            var userDtos = _mapper.Map<IList<UserDto>>(users);
            return Ok(userDtos);
        }

        [HttpGet("{userName}")]
        public async Task<IActionResult> GetByUserName(string userName)
        {
            User user;
            if (_userService.IsUserEditor(HttpContext.User))
            {
                user =  await _userService.GetByUserName(userName);                
            }
            else
            {
                user =  await _userService.GetByPrincipal(HttpContext.User);                
            }
            
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpPut("{userName}")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> UpdateAsync(string userName, [FromBody]UserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);

            try 
            {
                await _userService.UpdateAsync(user);
                return Ok();
            } 
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{userName}")]
        [Authorize(Roles="Manager,Admin")]
        public async Task<IActionResult> Delete(string userName)
        {
            await _userService.DeleteAsync(userName);
            return Ok();
        }
    }
}