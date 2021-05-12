using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datarynx.LocalDB.Models
{
   public class ToDoItem
    {
        [PrimaryKey, AutoIncrement]
        public int ToDoItemID { get; set; }
        public DateTime CreateDate { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public string CodingType { get; set; }
        public string TaskStatus { get; set; }

    }
}
