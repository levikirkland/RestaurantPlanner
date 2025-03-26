using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WaterUtilPro.Data;
using WaterUtilPro.Interfaces;
using WaterUtilPro.Models;
using WaterUtilPro.Repository;
using WaterUtilPro.Services;

namespace WaterUtilPro.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterRepos(this IServiceCollection collection)
        {
            collection.AddSingleton<ICurrentUserService, CurrentUserService>();
            collection.AddSingleton<ISqlDataAccess, SqlDataAccess>();
            collection.AddTransient<IDateTime, DateTimeService>();
            collection.AddTransient<IIdentityService, IdentityService>();
            collection.AddTransient<IInitializationService, InitializationService>();
            collection.AddTransient<IAccountInfoRepository, AccountRepository>();
            collection.AddTransient<IInventoryRepository, InventoryRepository>();
            collection.AddTransient<IUnitOfMeasureRepository, UnitOfMeasureRepository>();
            collection.AddTransient<ICategoryRepository, CategoryRepository>();
            collection.AddTransient<IVendorRepository, VendorRepository>();
            collection.AddTransient<IUserRespository, UserRespository>();
            collection.AddTransient<IOrderRepository, OrderRepsoitory>();
        }

        public static void RegisterLogging(this IServiceCollection collection)
        {

        }

        public static void RegisterAuth(this IServiceCollection collection, IConfiguration Configuration)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            collection.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString, options =>
                {
                    options.EnableRetryOnFailure(
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: new List<int> { 4060 }); //additional error codes to treat as transient
                }));



            collection.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(50);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            })
            .AddDefaultUI()
            .AddDefaultTokenProviders()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

            collection.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/UserManager/Login";
                options.LogoutPath = $"/UserManager/Logout";
                options.AccessDeniedPath = $"/UserManager/AccessDenied";
            });

            collection.AddAuthorization(options =>
            {
                options.AddPolicy("AdminAccess", policy => policy.RequireRole("Admin"));

                options.AddPolicy("ManagerAccess", policy =>
                    policy.RequireAssertion(context =>
                                context.User.IsInRole("Admin")
                                || context.User.IsInRole("Manager")));

                options.AddPolicy("AssociateAccess", policy =>
                    policy.RequireAssertion(context =>
                                context.User.IsInRole("Admin")
                                || context.User.IsInRole("Manager")
                                || context.User.IsInRole("Associate")));

                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });
        }
    }
}
