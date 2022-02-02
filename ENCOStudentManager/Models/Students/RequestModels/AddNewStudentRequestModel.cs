using System;

namespace ENCOStudentManager.Models.Students.RequestModels
{
    public class AddNewStudentRequestModel
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
    }
}
