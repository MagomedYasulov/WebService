using WebService.Extentions;
using WebService.Hubs;

namespace WebService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.AddData();
            builder.AddControllers();
            builder.AddSwagger();
            builder.AddFluentValidation();
            builder.AddAutoMapper();
            builder.AddSignalR();
            builder.AddExceptionHandler();
            builder.AddAppServices();
            
            var app = builder.Build();
            app.MigrateDB();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseExceptionHandler();
            app.UseAuthorization();

            app.MapHub<MessagesHub>("/messages");
            app.MapControllers();

            app.Run();
        }
    }
}
