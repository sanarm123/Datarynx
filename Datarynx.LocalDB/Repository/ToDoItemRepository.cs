using Datarynx.LocalDB.DBContext;
using Datarynx.LocalDB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Datarynx.LocalDB.Repository
{
    public class ToDoItemRepository : IToDoItemRepository
    {

        private readonly SqlLiteDatabaseContext _sqlLiteDatabaseContext;

        public ToDoItemRepository(SqlLiteDatabaseContext sqlLiteDatabaseContext)
        {
            _sqlLiteDatabaseContext = sqlLiteDatabaseContext;
        }
        public Task<int> AddItemAsync(ToDoItem item)
        {
            return _sqlLiteDatabaseContext.Connection.InsertAsync(item);
        }

        public Task<List<ToDoItem>> GetItemAsync()
        {
            return _sqlLiteDatabaseContext.Connection.Table<ToDoItem>().ToListAsync();

        }

        public async Task<ToDoItem> GetItemAsync(int id)
        {
            return await _sqlLiteDatabaseContext.Connection.Table<ToDoItem>().FirstOrDefaultAsync(c => c.ToDoItemID == id);
        }

       
    }
}
