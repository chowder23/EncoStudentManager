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
    public class StudentStatisticService : IStudentStatisticsService
    {
        private readonly IStudentManagerContext _context;
        public StudentStatisticService(IStudentManagerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IEnumerable<StudentStatisticsDto> GetStatisctics()
        {
            var querryStatistics = from students in _context.Students
                                   join grades in _context.Grades
                                   on students.Id equals grades.StudentId
                                   select new StudentStatisticsDto
                                   {
                                       StudentId = students.Id,
                                       Name = students.Name,
                                       Average = CalculateAverage(students.Grades),
                                       NumberOfOnes = CalculateNumberOfOnes(students.Grades),
                                       BestGrade = CalculateBestGrade(students.Grades)
                                   };

            var result = querryStatistics.ToList().Distinct().OrderBy(s => s.Average);

            List<StudentStatisticsDto> finalResult = new List<StudentStatisticsDto>();

            foreach (var stat in result)
            {
                if (finalResult.Where(s => s.StudentId == stat.StudentId).Count() == 0)
                {
                    finalResult.Add(stat);
                }
            }

            return finalResult;
        }

        #region private helpers
        private static double CalculateAverage(List<Grade> grades)
        {
            return Math.Round(grades.Average(g => g.Mark), 2);
        }
        private static int CalculateBestGrade(List<Grade> grades)
        {
            return grades.Max(g => g.Mark);
        }
        private static int CalculateNumberOfOnes(List<Grade> grades)
        {
            return grades.Count(g => g.Mark.Equals(1));
        }
        #endregion 
    }
}
