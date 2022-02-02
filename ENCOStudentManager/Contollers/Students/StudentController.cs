using ENCOStudentManager.Models.Students.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentManager.Logic.Modules.StudentModule.Dtos;
using StudentManager.Logic.Modules.StudentModule.Interfaces;
using System;

namespace ENCOStudentManager.Contollers.Students
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studnetService;
        private readonly UserManager<IdentityUser> _manager;

        public StudentController(IStudentService studentService, UserManager<IdentityUser> manager)
        {
            _studnetService = studentService;
            _manager = manager;
        }

        [HttpGet]
        [Route("GetAllStudents")]
        public IActionResult GetAllStudents()
        {
            try
            {
                return Ok(_studnetService.GetAllStudentOrderedByName());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddNewStudent([FromBody] AddNewStudentRequestModel rm)
        {
            var student = _studnetService.AddNewStudent(new AddNewStudentDto
            {
                Name = rm.Name,
                Year = rm.Year,
                DateOfBirth = rm.DateOfBirth,
                PhoneNumber = rm.PhoneNumber

            });

            if (student != null)
            {
                return Ok(student);
            }
            else
            {
                return BadRequest(student);
            }
        }

        [HttpGet]
        [Route("Statistics")]
        public IActionResult GetStatistics()
        {
            var statistics = _studnetService.GetStatisctics();
            return Ok(statistics);
        }

        [HttpPost]
        [Authorize]
        [Route("AddGrade")]
        public IActionResult AddGrade([FromBody] AddNewGradeRequestModel rm)
        {
            _studnetService.AddGradeToStudent(new MarkDto
            {
                StudentId = rm.StudentId,
                Mark = rm.Mark
            });
            return Ok(true);
        }
    }
}
