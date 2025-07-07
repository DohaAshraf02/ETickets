using ETickets.Data;
using ETickets.Repositories;

namespace ETickets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<CategoryRepository>();
            builder.Services.AddScoped<ActorRepository>();
            builder.Services.AddScoped<CinemaRepository>();
            builder.Services.AddScoped<MovieRepository>();
            builder.Services.AddScoped<ApplicationDbContext>();

            // Register AutoMapper
            builder.Services.AddAutoMapper(cfg => cfg.AddMaps(typeof(Program).Assembly));
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
