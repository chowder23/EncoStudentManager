using Microsoft.AspNetCore.Identity;
using StudentManager.Logic.Modules.Identity.Dto;
using StudentManager.Logic.Modules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Logic.Modules.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        public IdentityService(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }
        public bool LogIn(LogInDto logInDto)
        {
            SignInResult loginresult = _signInManager.PasswordSignInAsync(logInDto.Name, logInDto.Password, true, false).GetAwaiter().GetResult();
            if (loginresult.Succeeded)
            {
                return true;
            }
            return false;
        }

        public void LogOut()
        {
            _signInManager.SignOutAsync();
        }
    }
}
