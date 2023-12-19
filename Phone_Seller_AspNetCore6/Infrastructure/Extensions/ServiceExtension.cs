using Business;
using Business.Contracts;
using DataAccess;
using DataAccess.Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Phone_Seller_AspNetCore6.Models;
using Services;
using Services.Contracts;

namespace Phone_Seller_AspNetCore6.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("sqlconnection"),
                    b => b.MigrationsAssembly("Phone_Seller_AspNetCore6"));

                options.EnableSensitiveDataLogging(true);
            });
        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<CustomUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 5;
            })
                .AddEntityFrameworkStores<RepositoryContext>()
                .AddDefaultTokenProviders();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
                options.AddPolicy("EditorOnly", policy => policy.RequireRole("Editor"));
            });

        }
        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = "Phone_Seller_AspNetCore6.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<Cart>(c => SessionCart.GetCart(c));
        }
        public static void ConfigureRepositoryRegistration(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager,RepositoryManager>();
            services.AddScoped<IPhoneRepository,PhoneRepository>();
            services.AddScoped<IBrandRepository,BrandRepository>();
            services.AddScoped<IOrderRepository,OrderRepository>();
            services.AddScoped<IPhoneRatingRepository,PhoneRatingRepository>();
        }
        public static void ConfigureServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IAuthService,AuthManager>();
            services.AddScoped<IBrandService, BrandManager>();
            services.AddScoped<IOrderService,OrderManager>();
            services.AddScoped<IPhoneService,PhoneManager>();
            services.AddScoped<SlugService>();
        }
        public static void ConfigureRouting(this IServiceCollection services)
        {
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
            });
        }
    }
}
