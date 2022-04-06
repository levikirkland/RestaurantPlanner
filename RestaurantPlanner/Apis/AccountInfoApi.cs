using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
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
        }

        [NonAction]
        private static async Task<IResult> InsertAccountInfo(AccountInfo accountInfo, ApplicationDbContext context)
        {
            try
            {
                // AccountInfo.DomainEvents.Add(new CreateNewCompanyEvent(AccountInfo));

                await context.Accounts.AddAsync(accountInfo);
                await context.SaveChangesAsync();
                return Results.Ok();
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
    }
}
