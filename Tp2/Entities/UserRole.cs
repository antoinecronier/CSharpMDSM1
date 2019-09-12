using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp2.Entities.Schemas;

namespace Tp2.Entities
{
    [Table(UserRoleSchema.TABLE)]
    public class UserRole
    {
        private Int32? idUser;
        private Int32? idRole;

        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(User))]
        [Column(UserRoleSchema.ID_USER)]
        public Int32? IdUser
        {
            get { return idUser; }
            set { idUser = value; }
        }

        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(Role))]
        [Column(UserRoleSchema.ID_ROLE)]
        public Int32? IdRole
        {
            get { return idRole; }
            set { idRole = value; }
        }
    }
}
