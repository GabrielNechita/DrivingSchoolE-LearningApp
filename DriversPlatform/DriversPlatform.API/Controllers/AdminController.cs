using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DriversPlatform.BLL.DTOs;
using DriversPlatform.BLL.Services;
using DriversPlatform.DAL.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DriversPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AdminController : ControllerBase
    {

        private readonly IDriverService _driverService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IInstructorService _instructorService;
        private readonly UserManager<User> _userManager;
        private readonly IResourceService _resourceService;

        public AdminController(
            IDriverService driverService, ICategoryService categoryService, IMapper mapper, 
            IInstructorService instructorService, UserManager<User> userManager, IResourceService resourceService)
        {
            _driverService = driverService;
            _categoryService = categoryService;
            _mapper = mapper;
            _instructorService = instructorService;
            _userManager = userManager;
            _resourceService = resourceService;
        }

        [Authorize(Roles = "admin, driver, instructor")]
        [HttpGet("getCategories")]
        public IActionResult GetCategories()
        {
            try
            {

                return Ok(_categoryService.GetCategories());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "admin")]
        [HttpPost("addCategory")]
        public IActionResult AddCategory([FromBody] Category newCategory)
        {
            try
            {
                _categoryService.AddCategory(newCategory);

                return Created("", newCategory);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "admin")]
        [HttpDelete("deleteCategory")]
        public IActionResult DeleteCategory([FromQuery] int categoryId)
        {
            try
            {
                _categoryService.DeleteCategory(categoryId);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "admin")]
        [HttpPut("updateCategory")]
        public IActionResult UpdateCategory([FromBody] Category category)
        {
            try
            {
                _categoryService.UpdateCategory(category);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "admin")]
        [HttpGet("getDrivers")]
        public IActionResult GetDrivers()
        {
            try
            {
                var drivers = _driverService.GetDrivers();
                var driversDTO = _mapper.Map<List<Driver>, List<DriverDTO>>(drivers);
                return Ok(driversDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "admin")]
        [HttpDelete("deleteDriver")]
        public IActionResult DeleteDriver([FromQuery] int driverId)
        {
            try
            {
                _driverService.DeleteDriver(driverId);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "admin")]
        [HttpGet("getInstructors")]
        public IActionResult GetInstructors()
        {
            try
            {
                var instructorList = _instructorService.GetInstructors();
                var result = _mapper.Map<List<Instructor>, List<InstructorDTO>>(instructorList);

                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest("Error!");
            }

        }

        [HttpPost("addInstructor")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddInstructor([FromBody] InstructorDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = _mapper.Map<UserDTO, User>(model.User);

                var result = await _userManager.CreateAsync(user, model.User.Password);
                await _userManager.AddToRoleAsync(user, "instructor");

                if (!result.Succeeded)
                {
                    return BadRequest("Email already exists!");
                }

                var userAdded = _userManager.FindByNameAsync(user.Email).Result;

                var newInstructor = new Instructor()
                {
                    Salary = model.Salary,
                    HireDate = model.HireDate,
                    UserId = userAdded.Id

                };

                _instructorService.AddInstructor(newInstructor, model.Categories);

                var instructorDTO = _mapper.Map<Instructor, InstructorDTO>(newInstructor);

                return Created("", instructorDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [Authorize(Roles = "admin")]
        [HttpDelete("deleteInstructor")]
        public IActionResult DeleteInstructor([FromQuery] int instructorId)
        {
            try
            {
                _instructorService.DeleteInstructor(instructorId);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "admin")]
        [HttpPost("addResource")]
        public IActionResult AddResource([FromBody] Resource newResource)
        {
            try
            {
                _resourceService.AddResource(newResource);

                return Created("", newResource);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "admin, driver, instructor")]
        [HttpGet("getResources")]
        public IActionResult GetResources()
        {
            try
            {

                return Ok(_resourceService.GetResources());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "admin")]
        [HttpDelete("deleteResource")]
        public IActionResult DeleteResource([FromQuery] int resourceId)
        {
            try
            {
                _resourceService.DeleteResource(resourceId);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "admin, instructor, driver")]
        [HttpGet("getResourceById")]
        public IActionResult GetResourceById([FromQuery] int resourceId)
        {
            try
            {
                var resourceFile = _resourceService.GetResourceById(resourceId);
                return File(resourceFile, "application/pdf");
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
    }
}