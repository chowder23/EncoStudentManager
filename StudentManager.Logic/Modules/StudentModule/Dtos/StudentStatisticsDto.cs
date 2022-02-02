namespace StudentManager.Logic.Modules.StudentModule.Dtos
{
    public class StudentStatisticsDto
    {

        public StudentStatisticsDto()
        {

        }

        public string StudentId { get; init; }
        public string Name { get; init; }
        public double Average { get; init; }
        public int NumberOfOnes { get; init; }
        public int BestGrade { get; init; }

    }
}
