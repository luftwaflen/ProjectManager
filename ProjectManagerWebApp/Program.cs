using ProjectManagerCore.Managers;
using ProjectManagerCore.Models;
using ProjectManagerDependencies;
using ProjectManagerInfrastructure;

namespace ProjectManagerWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddRepositories(connection);

            builder.Services.AddIdentity<UserModel, RoleModel>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<PMDbContext>()
                .AddUserManager<CustomUserManager>();
            
            builder.Services.AddServices();
            
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
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // app.MapControllerRoute(
            //     name: "default",
            //     pattern: "{controller=Projects}/{action=Index}/{id?}");
            
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}");

            app.Run();
        }
    }
}