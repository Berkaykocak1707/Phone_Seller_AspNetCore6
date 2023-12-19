using Phone_Seller_AspNetCore6.Infrastructure.Extensions;

namespace Phone_Seller_AspNetCore6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.ConfigureDbContext(builder.Configuration);
            builder.Services.ConfigureIdentity();
            builder.Services.ConfigureRouting();
            builder.Services.ConfigureSession();
            builder.Services.ConfigureRepositoryRegistration();
            builder.Services.ConfigureServiceRegistration();
            builder.Services.AddAutoMapper(typeof(Program));
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.ConfigureAndCheckMigration();
            app.ConfigureLocalization();
            app.ConfigureDefaultAdminUser();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{slug?}");
                endpoints.MapRazorPages();

                endpoints.MapControllers();
            });


            app.Run();
        }
    }
}