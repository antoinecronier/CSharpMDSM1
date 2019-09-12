using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp2.Entities.Schemas
{
    public class UserSchema
    {
        public const String TABLE = "user";

        public const String ID = "id";
        public const String FIRSTNAME = "firstname";
        public const String LASTNAME = "lastname";
        public const String EMAIL = "email";

        public const String WHERE_USER_EMAIL = "WHERE " + EMAIL + " = @1";   
    }
}
