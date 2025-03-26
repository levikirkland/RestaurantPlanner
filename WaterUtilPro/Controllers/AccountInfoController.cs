using Microsoft.AspNetCore.Mvc;
using WaterUtilPro.Attributes;
using WaterUtilPro.Interfaces;
using WaterUtilPro.Models;

namespace WaterUtilPro.Controllers
{
    [Route("api/[controller]")]
    [ApiKey]
    public class AccountInfoController : ControllerBase
    {
        private readonly IAccountInfoRepository _repo;
        private readonly IInitializationService _initializationService;

        public AccountInfoController(IAccountInfoRepository repo, IInitializationService initializationService)
        {
            _repo = repo;
            _initializationService = initializationService;
        }

        [HttpPost]
        [Route("insertaccountinfo")]
        public async Task<IResult> InsertAccountInfo([FromBody] Account accountInfo)
        {
            try
            {
                await _repo.Add(accountInfo);
                await _initializationService.SeedNewSuperAdminUser(accountInfo);

                return Results.Ok(accountInfo);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("createnewsuperadminuser")]
        public async Task<IResult> CreateNewSuperAdminUser(Account accountInfo)
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
                int emailFound = await _repo.IsUniqueEmailAddress(EmailAddress);

                if (emailFound == 1)
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
