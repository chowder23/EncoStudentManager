using StudentManager.Logic.Modules.StudentModule.Dtos;
using System.Collections.Generic;

namespace StudentManager.Logic.Modules.StudentModule.Interfaces
{
    public interface IStudentStatisticsService
    {
        public IEnumerable<StudentStatisticsDto> GetStatisctics();
    }
}