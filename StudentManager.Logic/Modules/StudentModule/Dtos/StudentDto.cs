using System;

namespace StudentManager.Logic.Modules.StudentModule.Dtos
{
    public class StudentDto
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public int Year { get; init; }
        public DateTime DateOfBirth { get; init; }
        public string PhoneNumber { get; init; }

        public StudentDto() { }
    }
}
