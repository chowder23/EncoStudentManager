using Microsoft.EntityFrameworkCore;
using StudentManager.Data.Contexts;
using StudentManager.Data.Entities;
using StudentManager.Data.Interfaces;
using StudentManager.Logic.Modules.StudentModule.Dtos;
using StudentManager.Logic.Modules.StudentModule.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManager.Logic.Modules.StudentModule
{
    public class StudentService : IStudentService
    {
        private readonly IStudentManagerContext _context;
        private readonly IStudentStatisticsService _studentStatisticsService;
        public StudentService(IStudentManagerContext context, IStudentStatisticsService studentStatisticsService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _studentStatisticsService = new StudentStatisticService(context);
        }

        public IEnumerable<StudentDto> GetAllStudentOrderedByName()
        {
            return _context.Students.OrderBy(s => s.Name).Select(s => new StudentDto
            {
                Id = s.Id,
                Name = s.Name,
                Year = s.Year,
                DateOfBirth = s.DateOfBirth,
                PhoneNumber = s.PhoneNumber
            });
        }

        public Student AddNewStudent(AddNewStudentDto studentDto)
        {
            Student newStudent = new Student()
            {
                Name = studentDto.Name,
                Year = studentDto.Year,
                DateOfBirth = studentDto.DateOfBirth,
                PhoneNumber = studentDto.PhoneNumber
            };

            _context.Students.Add(newStudent);
            _context.SaveChanges();
            return newStudent;
        }
        public IEnumerable<StudentStatisticsDto> GetStatisctics()
        {
            return _studentStatisticsService.GetStatisctics();
        }

        public void AddGradeToStudent(MarkDto markDto)
        {
            var newGrade = new Grade() { StudentId = markDto.StudentId, Mark = markDto.Mark };
            _context.Students.Where(s => s.Id == markDto.StudentId).First().Grades.Add(newGrade);
            _context.SaveChanges();
        }

    }
}
