using Microsoft.AspNetCore.Mvc;
using RestaurantPlanner.Data;
using RestaurantPlanner.Models;

namespace RestaurantPlanner.Apis
{
    public static class AccountInfoApi
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapPost("/AccountInfo/InsertAccountInfo", InsertAccountInfo);
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
    }
}
