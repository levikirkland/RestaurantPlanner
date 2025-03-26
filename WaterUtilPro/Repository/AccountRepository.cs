using WaterUtilPro.Interfaces;
using WaterUtilPro.Models;
using WaterUtilPro.Repository.SqlStatements;
using System.Data;

namespace WaterUtilPro.Repository
{
    public class AccountRepository : IAccountInfoRepository
    {
        private readonly ISqlDataAccess _db;
        private readonly ICurrentUserService _currentUser;

        public AccountRepository(ISqlDataAccess db, ICurrentUserService currentUser)
        {
            _db = db;
            _currentUser = currentUser;
        }

        public async Task<int> Add(Account accountInfo)
        {
            var cts = new CancellationTokenSource();
            var parameters = new
            {
                Id = accountInfo.Id,
                CompanyName = accountInfo.CompanyName,
                FirstName = accountInfo.FirstName,
                LastName = accountInfo.LastName,
                EmailAddress = accountInfo.EmailAddress,
                Phone = accountInfo.Phone,
                Address1 = accountInfo.Address1,
                Address2 = accountInfo.Address2,
                City = accountInfo.City,
                State = accountInfo.State,
                Zipcode = accountInfo.Zipcode,
                AccountType = accountInfo.AccountType,
                SignUpDate = accountInfo.SignUpDate,
                IsActive = accountInfo.IsActive,
                CreatedDate = DateTime.Now,
                CreatedBy = _currentUser.UserId
            };

            await _db.SaveData("", parameters, ConnStrings.DefaultConnectionString, CommandType.Text, cts.Token); throw new NotImplementedException();
        }

        public async Task<bool> IsUniqueByAccountAndEmailAddress(string emailAddress, int id)
        {
            var cts = new CancellationTokenSource();

            var result = await _db.LoadSingleDataAsync<int, dynamic>(SqlQueries.Accounts.IsUniqueByAccountAndEmailAddress,
                new { EmailAddress = emailAddress, Id = id }, ConnStrings.DefaultConnectionString, CommandType.Text, cts.Token);

            if (result != 0)
                return true;

            return false;
        }

        public async Task<int> IsUniqueEmailAddress(string emailAddress)
        {
            var cts = new CancellationTokenSource();

            return await _db.LoadSingleDataAsync<int, dynamic>(SqlQueries.Accounts.IsUniqueEmail, new { EmailAddress = emailAddress }, "defaultConnection", CommandType.Text, cts.Token);
        }
    }
}
