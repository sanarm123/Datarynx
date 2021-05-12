using Datarynx.LocalDB.DBContext;
using Datarynx.LocalDB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Datarynx.LocalData
{
    public class ToDoItemDataRepository : IToDoItemDataRepository
    {
        private readonly SqlLiteDatabaseContext _sqlLiteDatabaseContext;

        public ToDoItemDataRepository()
        {
            _sqlLiteDatabaseContext = DependencyService.Get<SqlLiteDatabaseContext>();
        }
      
      
        public Task<int> AddItemAsync(ToDoItem item)
        {
           return  _sqlLiteDatabaseContext.SaveToDoItemSync(item);
           // throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ToDoItem>> GetItemAsync()
        {
          return _sqlLiteDatabaseContext.GetToDoItems();
        }

        public Task<ToDoItem> GetItemAsync(string id)
        {
            return _sqlLiteDatabaseContext.GetItemAsync(int.Parse(id));
        }

        public Task<bool> UpdateItemAsync(ToDoItem item)
        {
            throw new NotImplementedException();
        }
    }
}
