using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp2.Entities;
using SQLiteNetExtensions.Extensions;

namespace Tp2.Database
{
    public class SQLiteManager : SQLiteConnection
    {
        public SQLiteManager(String dbPath) : base(dbPath)
        {
            try
            {
                CreateTables();
            }
            catch (Exception e)
            {
                DropTables();
                CreateTables();
            }
        }

        private void DropTables()
        {
            this.DropTable<User>();
            this.DropTable<Role>();
            this.DropTable<Comment>();
            this.DropTable<UserRole>();
        }

        private void CreateTables()
        {
            this.CreateTable(typeof(Role));
            this.CreateTable(typeof(User));
            this.CreateTable(typeof(Comment));
            this.CreateTable(typeof(UserRole));
        }
    }
}
