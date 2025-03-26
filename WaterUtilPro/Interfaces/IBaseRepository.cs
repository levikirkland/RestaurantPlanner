namespace WaterUtilPro.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<int> Add<T>(in T sender);
        Task<int> Update<T>(in T sender);
        Task<int> DeleteById(int Id);
        Task<List<T>> GetAsync();
        Task<T> GetById(int id);
        Task<T> GetDetails(int Id);
    }
}