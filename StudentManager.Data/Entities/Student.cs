using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentManager.Data.Entities
{
    public class Student
    {
        #region Public Properties


        [Key]
        public string Id { get; set; }

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

        public virtual List<Grade> Grades { get; set; }

        #endregion

        #region ctors

        public Student()
        {
            Grades = new List<Grade>();
            Id = Guid.NewGuid().ToString();
        }

        #endregion
    }
}
