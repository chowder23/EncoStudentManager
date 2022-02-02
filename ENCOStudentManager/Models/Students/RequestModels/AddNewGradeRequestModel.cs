using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENCOStudentManager.Models.Students.RequestModels
{
    public class AddNewGradeRequestModel
    {
        public string StudentId { get; init; }
        public int Mark { get; init; }
    }
}
