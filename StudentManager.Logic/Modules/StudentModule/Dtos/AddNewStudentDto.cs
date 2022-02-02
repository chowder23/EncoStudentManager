using System;
using System.ComponentModel.DataAnnotations;

namespace StudentManager.Logic.Modules.StudentModule.Dtos
{
    public class AddNewStudentDto
    {
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [Range(1900, 2021)]
        public int Year { get; set; }
        public DateTime DateOfBirth { get; set; }
        [RegularExpression(@"((?:\+?3|0)6)(?:-|\()?(\d{1,2})(?:-|\))?(\d{3})-?(\d{3,4})")]
        public string PhoneNumber { get; set; }
    }
}
