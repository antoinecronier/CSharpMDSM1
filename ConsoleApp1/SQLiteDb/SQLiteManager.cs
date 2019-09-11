using SQLite.Net;
using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.MonProjet.SQLiteDb
{
    public class SQLiteManager<T> : SQLiteConnection where T : class
    {
        public SQLiteManager(String dbPath) : base(
            new SQLite.Net.Platform.Win32.SQLitePlatformWin32(), 
            dbPath)
        {
            try
            {
                this.CreateTable(typeof(T));
            }
            catch (Exception)
            {
                this.MigrateTable(typeof(T));
            }
        }
    }
}
