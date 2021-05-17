using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Datarynx.LocalDB.Models
{
   public class ToDoItem
    {
        [PrimaryKey, AutoIncrement]
        [DisplayName("To Do ItemID")]
        public int ToDoItemID { get; set; }

        [DisplayName("Created Date")]
        public DateTime CreateDate { get; set; }

        [DisplayName("Store Name")]
        public string StoreName { get; set; }

        [DisplayName("Store Address")]
        public string StoreAddress { get; set; }

        [DisplayName("Coding Type")]
        public string CodingType { get; set; }

        [DisplayName("Task Status")]
        public string TaskStatus { get; set; }

        [DisplayName("Week No")]
        public string WeekNo { get; set; }

        [DisplayName("Week Date")]
        public string WeekDate { get; set; }


    }
}
