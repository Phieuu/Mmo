using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileApp.Services.Database
{
    public interface IFirebaseDatabaseService
    {
        Task<bool> AddItemAsync<T>(T item);
        Task<bool> UpdateItemAsync<T>(string id, T item);
        Task<bool> DeleteItemAsync<T>(string id);
        Task<T> GetItemAsync<T>();
        Task<IEnumerable<T>> GetItemsAsync<T>(bool forceRefresh = false);
    }
}