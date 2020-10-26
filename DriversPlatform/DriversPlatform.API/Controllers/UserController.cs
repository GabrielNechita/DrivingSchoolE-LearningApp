using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DriversPlatform.BLL.DTOs;
using DriversPlatform.BLL.Services;
using DriversPlatform.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DriversPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IDriverService _driverService;
        private IUserService _usersService;

        public UserController(UserManager<User> userManager, 
            SignInManager<User> signInManager, 
            IMapper mapper, 
            IDriverService driverService, 
            IUserService usersService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _driverService = driverService;
            _usersService = usersService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] UserDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = _mapper.Map<UserDTO, User>(model);

                var result = await _userManager.CreateAsync(user, model.Password);
                await _userManager.AddToRoleAsync(user, "driver");

                if (!result.Succeeded)
                {
                    return BadRequest("Email already exists!");
                }

                var userAdded = _userManager.FindByNameAsync(user.Email).Result;

                var newDriver = new Driver()
                {
                    EnrollmentDate = DateTime.Now,
                    UserId = userAdded.Id
                };

                _driverService.AddDriver(newDriver);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromBody] UserDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {          
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                if (!result.Succeeded)
                {
                    return BadRequest("Adresa email sau parola incorecta!");
                }

                var user = await _userManager.FindByEmailAsync(model.Email);
                var role = await _userManager.GetRolesAsync(user);
                var token = _usersService.CreateToken(model.Email, role[0]);

                var results = new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    userRole = role,
                    email = user.Email
                };
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(500, "Server Error!");
            }
        }
    }
}