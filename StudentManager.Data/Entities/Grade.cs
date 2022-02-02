using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManager.Data.Entities
{
    public class Grade
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string StudentId { get; set; }

        [Range(1, 6)]
        public int Mark { get; set; }

        public Grade()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
