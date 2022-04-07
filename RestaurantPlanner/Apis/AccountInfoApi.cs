using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantPlanner.Common.Enums;
using RestaurantPlanner.Data;
using RestaurantPlanner.Interfaces;
using RestaurantPlanner.Models;
using RestaurantPlanner.Services;

namespace RestaurantPlanner.Apis
{
    public static class AccountInfoApi
    {

        public static void ConfigureApi(this WebApplication app)
        {
            app.MapPost("/AccountInfo/InsertAccountInfo", InsertAccountInfo);
            app.MapPost("/AccountInfo/CreateNewSuperAdminUser", CreateNewSuperAdminUser);
            app.MapGet("/AccountInfo/IsUniqueEmail", IsUniqueEmail);
        }

        [NonAction]
        private static async Task<IResult> InsertAccountInfo(AccountInfo accountInfo, ApplicationDbContext context, [FromServices] IInitializationService service)
        {
            try
            {
                // AccountInfo.DomainEvents.Add(new CreateNewCompanyEvent(AccountInfo));

                await context.Accounts.AddAsync(accountInfo);
                await context.SaveChangesAsync();

                await service.SeedNewSuperAdminUser(accountInfo);

                return Results.Created($"/AccountInfo/InsertAccountInfo/{accountInfo.Id}", accountInfo);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [NonAction]
        private static async Task<IResult> CreateNewSuperAdminUser(AccountInfo accountInfo, [FromServices] IInitializationService service)
        {
            try
            {                
                await service.SeedNewSuperAdminUser(accountInfo);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [NonAction]
        private static async Task<IResult> IsUniqueEmail(string EmailAddress, ApplicationDbContext context)
        {            
            try
            {
                var emailFound = await context.Accounts.AnyAsync(l => l.EmailAddress == EmailAddress);
                if (emailFound)
                    return Results.Created($"/AccountInfo/IsUniqueEmail/{EmailAddress}", false); //not Unique

                return Results.Created($"/AccountInfo/IsUniqueEmail/{EmailAddress}", true); //is unique
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);

            }
        }
    }
}
