using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp2.Entities.Schemas;

namespace Tp2.Entities
{
    [Table(RoleSchema.TABLE)]
    public class Role
    {
        private int? id;
        private String name;

        [PrimaryKey]
        [AutoIncrement]
        [Column(RoleSchema.ID)]
        public int? Id
        {
            get { return id; }
            set { id = value; }
        }

        [Column(RoleSchema.NAME)]
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public Role()
        {

        }

        public override string ToString()
        {
            return String.Format("\"{0}\":\"{1}\",\"{2}\":\"{3}\"",
                RoleSchema.ID, this.Id,
                RoleSchema.NAME, this.Name);
        }
    }
}
