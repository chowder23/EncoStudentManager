using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentManager.Data.Contexts;

namespace ENCOStudentManager.Configuration
{
    public static partial class ConfigurationExtensions
    {
        public static IApplicationBuilder InitializeData(this IApplicationBuilder app, IConfiguration config)
        {
            var scope = app.ApplicationServices.CreateScope();

            var context = scope.ServiceProvider.GetService<StudentManagerContext>();
            var userManager = scope.ServiceProvider.GetService<UserManager<IdentityUser>>();
            StudentManagerContext.SeedData(context, userManager);

            return app;
        }
    }
}
