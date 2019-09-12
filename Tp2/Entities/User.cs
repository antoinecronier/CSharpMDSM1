using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp2.Entities.Schemas;

namespace Tp2.Entities
{
    [Table(UserSchema.TABLE)]
    public class User
    {
        private int? id;
        private String firstname;
        private String lastname;
        private String email;
        private List<Role> roles;

        [PrimaryKey]
        [AutoIncrement]
        [Column(UserSchema.ID)]
        public int? Id
        {
            get { return id; }
            set { id = value; }
        }

        [Column(UserSchema.FIRSTNAME)]
        public String Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        [Column(UserSchema.LASTNAME)]
        public String Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        [Column(UserSchema.EMAIL)]
        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        //[Column(UserSchema.ROLES)]
        [ManyToMany(typeof(UserRole))]
        public List<Role> Roles
        {
            get { return roles; }
            set { roles = value; }
        }

        public User()
        {

        }

        public override string ToString()
        {
            return String.Format("\"{0}\":\"{1}\",\"{2}\":\"{3}\",\"{4}\":\"{5}\",\"{6}\":\"{7}\"",
                UserSchema.ID, this.Id,
                UserSchema.FIRSTNAME, this.Firstname,
                UserSchema.LASTNAME, this.Lastname,
                UserSchema.EMAIL, this.Email,
                "Roles", this.Roles);
        }
    }
}
