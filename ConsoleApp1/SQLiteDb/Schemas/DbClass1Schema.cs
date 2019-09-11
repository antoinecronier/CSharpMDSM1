using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.MonProjet.SQLiteDb.Schemas
{
    public class DbClass1Schema
    {
        public const String TABLE = "address";
        public const String ID = "Id";
        public const String WAY = "Way";
        public const String NUMBER = "Number";

        public const String PREFIX_ID = TABLE + "." + ID;
        public const String PREFIX_WAY = TABLE + "." + WAY;
        public const String PREFIX_NUMBERE = TABLE + "." + NUMBER;

        public const String ALL_TABLE_ELEMENT = TABLE + ".*";

        public List<String> GetColumns()
        {
            List<String> result = new List<String>();
            result.Add(ID);
            result.Add(WAY);
            result.Add(NUMBER);
            return result;
        }
    }
}
