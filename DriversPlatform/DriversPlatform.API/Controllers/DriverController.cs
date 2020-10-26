using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DriversPlatform.BLL.DTOs;
using DriversPlatform.BLL.Services;
using DriversPlatform.DAL.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DriversPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public DriverController(IDriverService driverService, UserManager<User> userManager, IMapper mapper)
        {
            _driverService = driverService;
            _userManager = userManager;
            _mapper = mapper;
        }

        [Authorize(Roles = "admin, driver")]
        [HttpGet("getDriverByEmail")]
        public IActionResult GetDriverByEmail([FromQuery]string email)
        {
            try
            {
                var user = _userManager.FindByNameAsync(email).Result;
                var driver = _driverService.GetDriverByUserId(user.Id);
                var driverDTO = _mapper.Map<Driver, DriverDTO>(driver);
                return Ok(driverDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        [Authorize(Roles = "admin, driver")]
        [HttpPut("updateDriver")]
        public IActionResult UpdateDriver([FromBody]DriverDTO driverDTO)
        {
            if (driverDTO == null)
            {
                return BadRequest("Error");

            }

            try
            {
                var driver = _mapper.Map<DriverDTO, Driver>(driverDTO);
                _driverService.UpdateDriver(driver);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }

        }

        [Authorize(Roles = "admin, driver")]
        [HttpPost("addCategoryToDriver")]
        public IActionResult AddCategoryToDriver([FromQuery] int driverId, [FromQuery] string categoryName)
        {
            if (driverId == 0 || categoryName == null)
            {
                return BadRequest("Error");

            }

            try
            {
                _driverService.AddCategoryToDriver(driverId, categoryName);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }

        }

        [Authorize(Roles = "admin, driver")]
        [HttpPost("addInstructorToDriver")]
        public IActionResult AddInstructorToDriver([FromQuery] int driverId, [FromQuery] int instructorId)
        {
            if (driverId == 0 || instructorId == 0)
            {
                return BadRequest("Error");

            }

            try
            {
                _driverService.AddInstructorToDriver(driverId, instructorId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }

        }

        [Authorize(Roles = "driver")]
        [HttpGet("getQuizByDifficultyAndCategory")]
        public IActionResult GetQuizByDifficultyAndCategory([FromQuery] int categoryId, [FromQuery] string difficulty)
        {
            try
            {
                
                var questions = _driverService.GetQuizByDifficultyAndCategory(difficulty, categoryId);
            
                return Ok(questions);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "driver")]
        [HttpGet("getQuizByCategory")]
        public IActionResult GetQuizByCategory([FromQuery] int categoryId)
        {
            try
            {
               
                var questions = _driverService.GetQuizByCategory(categoryId);
                return Ok(questions);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "driver")]
        [HttpPost("addQuizResult")]
        public IActionResult AddQuizResult([FromBody] QuizResult result)
        {
            if (result == null)
            {
                return BadRequest("Error");

            }
            try
            {
                _driverService.AddQuizResult(result);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }

        }


    }
}