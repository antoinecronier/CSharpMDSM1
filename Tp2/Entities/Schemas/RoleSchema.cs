using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp2.Entities.Schemas
{
    public class RoleSchema
    {
        public const String TABLE = "role";

        public const String ID = "id";
        public const String NAME = "name";

        public const String WHERE_ROLE_NAME = "WHERE " + NAME + " = @1";
    }
}
