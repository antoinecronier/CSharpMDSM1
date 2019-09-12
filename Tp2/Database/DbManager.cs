using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp2.Entities;
using Tp2.Entities.Schemas;

namespace Tp2.Database
{
    public class DbManager
    {
        private const String SELECT_ALL = "SELECT * FROM ";

        private const String DB_PATH = "\\tp2.sqlite";
        private readonly SQLiteManager sqliteManager = new SQLiteManager(Environment.CurrentDirectory + DB_PATH);

        public SQLiteManager SqliteManager => sqliteManager;

        public void Save(object item)
        {
            SqliteManager.InsertOrReplaceWithChildren(item);
        }

        public List<Role> GetAllRole()
        {
            //return sqliteManager.Query<Role>(SELECT_ALL + RoleSchema.TABLE);
            return SqliteManager.GetAllWithChildren<Role>();
        }

        public List<User> GetAllUser()
        {
            //return sqliteManager.Query<User>(SELECT_ALL + UserSchema.TABLE);
            return SqliteManager.GetAllWithChildren<User>();
        }

        public List<Comment> GetAllComment()
        {
            //return sqliteManager.Query<Comment>(SELECT_ALL + CommentSchema.TABLE);
            return SqliteManager.GetAllWithChildren<Comment>();
        }

        public List<T> GetAll<T>() where T : class, new()
        {
            return SqliteManager.GetAllWithChildren<T>();
        }

        public Role GetRoleByName(String name)
        {
            return SqliteManager.Query<Role>(SELECT_ALL + RoleSchema.WHERE_ROLE_NAME, name).First();
        }

        public User GetUserByEmail(String email)
        {
            return SqliteManager.Query<User>(SELECT_ALL + UserSchema.WHERE_USER_EMAIL, email).First();
        }

        public List<T> GetByField<T>(String field, String value) where T : class, new()
        {
            return SqliteManager.Query<T>(SELECT_ALL + " WHERE " + field + " = " + value);
        }
    }
}
