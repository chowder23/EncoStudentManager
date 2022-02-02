using StudentManager.Data.Entities;
using StudentManager.Logic.Modules.StudentModule.Dtos;
using System.Collections.Generic;

namespace StudentManager.Logic.Modules.StudentModule.Interfaces
{
    public interface IStudentService
    {
        public IEnumerable<StudentDto> GetAllStudentOrderedByName();

        public Student AddNewStudent(AddNewStudentDto studentDto);
        public IEnumerable<StudentStatisticsDto> GetStatisctics();

        public void AddGradeToStudent(MarkDto markDto);
    }
}