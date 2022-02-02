using ENCOStudentManager.Models.Identity.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManager.Logic.Modules.Identity.Dto;
using StudentManager.Logic.Modules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENCOStudentManager.Contollers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("LogIn")]
        public IActionResult LogIn([FromBody] LogInRequestModel rm)
        {
            return Ok(_identityService.LogIn(new LogInDto
            {
                Name = rm.Username,
                Password = rm.Password
            }));
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("LogOut")]
        public IActionResult LogOut()
        {
            _identityService.LogOut();
            return Ok();
        }

    }
}
