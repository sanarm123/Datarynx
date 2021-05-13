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
       public readonly SQLiteAsyncConnection _sqlLiteAsyncConnection;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbPath"></param>
        public SqlLiteDatabaseContext()
        {

            if (_sqlLiteAsyncConnection == null)
            {
                _sqlLiteAsyncConnection = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Datarynx.db3"));
                _sqlLiteAsyncConnection.CreateTableAsync<ToDoItem>().Wait();

                //Get Items Count, if items count is zero then add manually.

            }
          

        }
     
        public SQLiteAsyncConnection Connection
        {
            get { return _sqlLiteAsyncConnection; }
           
        }

    }
}
