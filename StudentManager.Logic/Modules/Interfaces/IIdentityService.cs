using StudentManager.Logic.Modules.Identity.Dto;

namespace StudentManager.Logic.Modules.Interfaces
{
    public interface IIdentityService
    {
        bool LogIn(LogInDto dto);
        void LogOut();
    }
}
