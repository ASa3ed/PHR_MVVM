using Infrastructure.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IStorageProvider
    {
        Task<T> GetItemAsync<T>(object key) where T : OfflineDataModel, new();
        Task<T> GetItemAsync<T>(Expression<Func<T, bool>> query) where T : OfflineDataModel, new();
        Task<IEnumerable<T>> GetAllItemsAsync<T>(Expression<Func<T, bool>> query, int pageSize = 0) where T : OfflineDataModel, new();
        Task<bool> SetItemAsync<T>(T data) where T : OfflineDataModel, new();
        Task<bool> SetAllItemsAsync<T>(IEnumerable<T> items) where T : OfflineDataModel, new();
        Task<bool> DeleteItemAsync<T>(object key) where T : OfflineDataModel;
        Task<bool> DeleteAll<T>() where T : OfflineDataModel;
        Task<List<T>> ExecuteQuery<T>(string query);
        Task<bool> HasData<T>() where T : OfflineDataModel, new();
        Task DeleteAllItemsAsync<T>(List<T> items) where T : OfflineDataModel, new();
        Task<int> UpdateAll<T>(List<T> items) where T : OfflineDataModel, new();
        Task<int> Update(object item);
    }
}
