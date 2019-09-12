using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp2.Entities.Schemas
{
    public class CommentSchema
    {
        public const String TABLE = "comment";

        public const String ID = "id";
        public const String COMMENT_AT = "comment_at";
        public const String DATA = "data";
        public const String FK_USER_TO = "user_to";
        public const String FK_USER_FROM = "user_from";
    }
}
