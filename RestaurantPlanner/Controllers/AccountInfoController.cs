using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantPlanner.Data;
using RestaurantPlanner.Interfaces;
using RestaurantPlanner.Models;

namespace RestaurantPlanner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountInfoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AccountInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
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
    }
}
