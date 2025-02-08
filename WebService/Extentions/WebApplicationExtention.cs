using Microsoft.EntityFrameworkCore;
using WebService.Data;

namespace WebService.Extentions
{
    public static class WebApplicationExtention
    {
        public static WebApplication MigrateDB(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
            dbContext.Database.Migrate();
            return app;
        }
    }
}
