using Datarynx.LocalDB.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Datarynx.LocalDB.DBContext
{
   public class SqlLiteDatabaseContext
    {
        readonly SQLiteAsyncConnection _sqlLiteAsyncConnection;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbPath"></param>
        public SqlLiteDatabaseContext()
        {
              
            _sqlLiteAsyncConnection = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Datarynx.db3"));
                _sqlLiteAsyncConnection.CreateTableAsync<ToDoItem>().Wait();
          
        }

        /// <summary>
        /// SaveToDoItemSync
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Task<int> SaveToDoItemSync(ToDoItem item)
        {
            return _sqlLiteAsyncConnection.InsertAsync(item);
        }

        /// <summary>
        /// GetToDoItems
        /// </summary>
        /// <returns></returns>
        public Task<List<ToDoItem>> GetToDoItems()
        {
            return _sqlLiteAsyncConnection.Table<ToDoItem>().ToListAsync();
        }

        public async Task<ToDoItem> GetItemAsync(int id)
        {
            return await _sqlLiteAsyncConnection.Table<ToDoItem>().FirstOrDefaultAsync(c=>c.ToDoItemID==id);
        }
    }
}
