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
    public class InstructorController : ControllerBase
    {

        
        private readonly IMapper _mapper;
        private readonly IInstructorService _instructorService;
        private readonly IQuestionService _questionService;
        private readonly UserManager<User> _userManager;

        public InstructorController(IMapper mapper, IInstructorService instructorService, IQuestionService questionService, UserManager<User> userManager)
        {
            _mapper = mapper;
            _instructorService = instructorService;
            _questionService = questionService;
            _userManager = userManager;
        }

        [Authorize(Roles = "admin, instructor")]
        [HttpGet("getInstructorByEmail")]
        public IActionResult GetInstructorByEmail([FromQuery]string email)
        {
            try
            {
                var user = _userManager.FindByNameAsync(email).Result;
                var instructor = _instructorService.GetInstructorByUserId(user.Id);
                var instructorDTO = _mapper.Map<Instructor, InstructorDTO>(instructor);
                return Ok(instructorDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "admin, driver")]
        [HttpGet("getInstructorsByCategory")]
        public IActionResult GetInstructorsByCategory([FromQuery]string category)
        {
            try
            {
                var instructorList = _instructorService.GetInstructorsByCategory(category);
                var result = _mapper.Map<List<Instructor>,List < InstructorDTO >> (instructorList);

                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest("Error!");
            }

        }

        [Authorize(Roles = "admin, instructor")]
        [HttpPut("updateInstructor")]
        public IActionResult UpdateInstructor([FromBody]InstructorDTO instructorDTO)
        {
            if (instructorDTO == null)
            {
                return BadRequest("Error");

            }

            try
            {
                var instructor = _mapper.Map<InstructorDTO, Instructor>(instructorDTO);
                _instructorService.UpdateInstructor(instructor, instructorDTO.Categories);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }

        }

        [Authorize(Roles = "admin, instructor")]
        [HttpPost("addQuestion")]
        public IActionResult AddQuestion([FromBody] Question newQuestion)
        {
            if (newQuestion == null || newQuestion.Answers == null)
            {
                return BadRequest("Error");
            }
            try
            {
                _questionService.AddQuestion(newQuestion);

                return Created("", newQuestion);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "admin, instructor")]
        [HttpDelete("deleteQuestion")]
        public IActionResult DeleteQuestion([FromQuery] int questionId)
        {
            try
            {
                _questionService.DeleteQuestion(questionId);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "admin, instructor")]
        [HttpGet("searchQuestion")]
        public IActionResult SearchQuestion([FromQuery] string searchText)
        {
            try
            {
                var questionList = _questionService.SearchQuestion(searchText);

                return Ok(questionList);
            }
            catch (Exception)
            {

                return BadRequest("Error!");
            }

        }

        [Authorize(Roles = "admin, instructor")]
        [HttpPost("giveQuizAccess")]
        public IActionResult GiveQuizAccess([FromBody] int? driverId)
        {
            if (driverId == null)
            {
                return BadRequest("Error");
            }
            try
            {
                _instructorService.GiveQuizAccess(driverId);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


    }
}