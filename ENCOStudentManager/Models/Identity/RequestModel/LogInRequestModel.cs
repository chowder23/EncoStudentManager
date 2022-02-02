using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENCOStudentManager.Models.Identity.RequestModel
{
    public class LogInRequestModel
    {
        public string Username { get; init; }
        public string Password { get; init; }
    }
}
