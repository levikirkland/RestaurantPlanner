using WaterUtilPro.Models;

namespace WaterUtilPro.Interfaces
{
    public interface IAccountInfoRepository
    {
        Task<int> Add(Account accountInfo);

        Task<bool> IsUniqueByAccountAndEmailAddress(string emailAddress, int id);
        Task<int> IsUniqueEmailAddress(string emailAddress);
    }
}