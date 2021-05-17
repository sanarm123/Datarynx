using Datarynx.LocalDB.DBContext;
using Datarynx.LocalDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datarynx.LocalDB.Repository
{
    public class ToDoItemRepository : IToDoItemRepository
    {

        private readonly SqlLiteDatabaseContext _sqlLiteDatabaseContext;

        public ToDoItemRepository()
        {
            _sqlLiteDatabaseContext = new SqlLiteDatabaseContext();
        }

     
        public Task<int> AddItemAsync(ToDoItem item)
        {
           
            if (item is null)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new NullReferenceException("Null value passsed");
#pragma warning restore S112 // General exceptions should never be thrown
            }

            return _sqlLiteDatabaseContext.Connection.InsertAsync(item);

        }


        public Task<List<ToDoItem>> GetItemAsync(string searchCriteria)
        {
            if (!string.IsNullOrEmpty(searchCriteria))
            {
                return _sqlLiteDatabaseContext.Connection.Table<ToDoItem>().Where(c=>c.StoreName.ToUpper().Contains(searchCriteria.ToUpper())|| c.WeekNo.ToUpper().Contains(searchCriteria.ToUpper())).ToListAsync();
            }
            return _sqlLiteDatabaseContext.Connection.Table<ToDoItem>().ToListAsync();

        }

        public async Task<ToDoItem> GetItemAsync(int id)
        {
            return await _sqlLiteDatabaseContext.Connection.Table<ToDoItem>().FirstOrDefaultAsync(c => c.ToDoItemID == id);
        }

       
    }
}
