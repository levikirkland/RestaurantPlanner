using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantPlanner.Attributes;
using RestaurantPlanner.Data;
using RestaurantPlanner.Interfaces;
using RestaurantPlanner.Models;

namespace RestaurantPlanner.Controllers
{
    [Route("api/[controller]")]
    [ApiKey]
    public class AccountInfoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IInitializationService _initializationService;

        public AccountInfoController(ApplicationDbContext context, IInitializationService initializationService)
        {
            _context = context;
            _initializationService = initializationService;
        }

        [HttpPost]
        [Route("insertaccountinfo")]
        public async Task<IResult> InsertAccountInfo([FromBody] AccountInfo accountInfo)
        {
            try
            {
                await _context.Accounts.AddAsync(accountInfo);
                await _context.SaveChangesAsync();

                await _initializationService.SeedNewSuperAdminUser(accountInfo);

                return Results.Ok(accountInfo);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("createnewsueradminuser")]
        public async Task<IResult> CreateNewSuperAdminUser(AccountInfo accountInfo)
        {
            try
            {
                await _initializationService.SeedNewSuperAdminUser(accountInfo);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("issuniqueemail")]
        public async Task<IResult> IsUniqueEmail(string EmailAddress)
        {
            try
            {
                var emailFound = await _context.Accounts.AnyAsync(l => l.EmailAddress == EmailAddress);
                if (emailFound)
                    return Results.Ok(false); //not Unique

                return Results.Ok(true); //is unique
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);

            }
        }
    }
}
