
namespace DAL.DbAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string StoredProcedure, U Parameters, string ConnectionId = "Default");
        Task SaveData<T>(string StoredProcedure, T Parameters, string ConnectionId = "Default");
    }
}