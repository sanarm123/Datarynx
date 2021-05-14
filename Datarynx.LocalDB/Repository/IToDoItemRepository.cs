using Datarynx.LocalDB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Datarynx.LocalDB.Repository
{
   public interface IToDoItemRepository
    {
        Task<int> AddItemAsync(ToDoItem item);
      
        Task<List<ToDoItem>> GetItemAsync(string searchCriteria);

        Task<ToDoItem> GetItemAsync(int id);
     
    }
}
