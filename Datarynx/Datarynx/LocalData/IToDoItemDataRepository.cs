using Datarynx.LocalDB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Datarynx.LocalData
{
   public interface IToDoItemDataRepository
    {
        Task<int> AddItemAsync(ToDoItem item);
        Task<bool> UpdateItemAsync(ToDoItem item);
        Task<bool> DeleteItemAsync(string id);
        Task<List<ToDoItem>> GetItemAsync();

        Task<ToDoItem> GetItemAsync(string id);
    }
}
