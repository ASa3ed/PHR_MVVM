using Infrastructure.Abstracts;
using Infrastructure.Extensions;
using Infrastructure.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensionsAsync.Extensions;

namespace Infrastructure.Providers
{
    public class SqliteStorageProvider : IStorageProvider
    {
        private SQLiteAsyncConnection con;
        public SqliteStorageProvider()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "offline.db3");
            con = new SQLiteAsyncConnection(path);
        }
        public async Task<bool> DeleteAll<T>() where T : OfflineDataModel
        {
            if (!(await TableExists<T>()))
                return false;

            int rows = await this.con.DeleteAllAsync<T>();
            return rows > 0;
        }

        public async Task<bool> DeleteItemAsync<T>(object key) where T : OfflineDataModel
        {
            if (!(await TableExists<T>()))
                return false;

            int rows = await this.con.DeleteAsync<T>(key);
            return rows > 0;
        }

        public async Task<IEnumerable<T>> GetAllItemsAsync<T>(Expression<Func<T, bool>> query, int pageSize = 0) where T : OfflineDataModel, new()
        {
            await this.con.CreateTableAsync<T>();

            var expression = this.con.Table<T>().Where(query);

            if (pageSize != 0)
                expression = expression.Take(pageSize);

            var items = await expression.ToListAsync();
            return items;
        }

        public async Task<T> GetItemAsync<T>(object key) where T : OfflineDataModel, new()
        {
            //if (!(await TableExists<T>()))
            //    return null;

            var item = await this.con.GetAsync<T>(key);
            return item;
        }

        public async Task<T> GetItemAsync<T>(Expression<Func<T, bool>> query) where T : OfflineDataModel, new()
        {
            if (!(await TableExists<T>()))
                return null;

            var item = await this.con.Table<T>().Where(query).FirstOrDefaultAsync();
            return item;
        }

        private object lockObj;
        public async Task<bool> SetAllItemsAsync<T>(IEnumerable<T> items) where T : OfflineDataModel, new()
        {
            try
            {
                await con.CreateTableAsync<T>();

                //await this.con.InsertOrReplaceAllWithChildrenAsync(items);
                int rows = await this.con.InsertOrReplaceAll(items);
                return rows > 0;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> SetItemAsync<T>(T data) where T : OfflineDataModel, new()
        {
            if (!(await TableExists<T>()))
                await con.CreateTableAsync<T>();

            int rows = await this.con.InsertOrReplaceAsync(data);
            return rows > 0;
        }

        private async Task<bool> TableExists<T>()
        {
            try
            {
                string query = $"SELECT * FROM sqlite_master WHERE type = 'table' AND tbl_name = '{typeof(T).Name}'";
                int rows = await con.ExecuteAsync(query);
                return rows > 0;
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public async Task<List<T>> ExecuteQuery<T>(string query)
        {
            var cmd = new SQLiteCommand(this.con.GetConnection());
            cmd.CommandText = query;

            return cmd.ExecuteQuery<T>();
        }

        public async Task<bool> HasData<T>() where T : OfflineDataModel, new()
        {
            bool hasData;
            try
            {
                hasData = (await this.con.Table<T>().CountAsync()) > 0;
            }
            catch(Exception ex)
            {
                hasData = false;
                Debug.WriteLine(ex);
            }

            return hasData;
        }
    }
}
