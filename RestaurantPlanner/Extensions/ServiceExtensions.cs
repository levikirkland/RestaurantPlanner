using RestaurantPlanner.Data;
using RestaurantPlanner.Interfaces;
using RestaurantPlanner.Models;
using RestaurantPlanner.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System;

namespace RestaurantPlanner.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterRepos(this IServiceCollection collection)
{
            collection.AddSingleton<ICurrentUserService, CurrentUserService>();
            collection.AddTransient<IDateTime, DateTimeService>();
            collection.AddTransient<IIdentityService, IdentityService>();
            collection.AddTransient<IDomainEventService, DomainEventService>();
            collection.AddMediatR(Assembly.GetExecutingAssembly());
        }

        public static void RegisterLogging(this IServiceCollection collection)
        {

        }
        public static void RegisterAuth(this IServiceCollection collection, IConfiguration Configuration)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            collection.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
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
            })
            .AddDefaultUI()
            .AddDefaultTokenProviders()
            //.AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

            //collection.ConfigureApplicationCookie(options =>
            //{
            //    options.LoginPath = $"/Identity/Account/Login";
            //    options.LogoutPath = $"/Identity/Account/Logout";
            //    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            //});

            //collection.AddAuthorization(options =>
            //{
            //    options.AddPolicy("AdminAccess", policy => policy.RequireRole("Admin"));

            //    options.AddPolicy("ManagerAccess", policy =>
            //        policy.RequireAssertion(context =>
            //                    context.User.IsInRole("Admin")
            //                    || context.User.IsInRole("Manager")));

            //    options.AddPolicy("AssociateAccess", policy =>
            //        policy.RequireAssertion(context =>
            //                    context.User.IsInRole("Admin")
            //                    || context.User.IsInRole("Manager")
            //                    || context.User.IsInRole("Associate")));
            //});
        }
    }
}
