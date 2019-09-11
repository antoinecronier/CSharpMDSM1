using ConsoleApp1.MonProjet.SQLiteDb.Schemas;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.MonProjet.SQLiteDb.Entities
{
    [Table(DbClass1Schema.TABLE)]
    public class DbClass1
    {
        private Int32 id;
        private String way;
        private Int32 number;

        [PrimaryKey]
        [AutoIncrement]
        [Column(DbClass1Schema.ID)]
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        [Column(DbClass1Schema.WAY)]
        public String Way
        {
            get { return way; }
            set { way = value; }
        }

        [Column(DbClass1Schema.NUMBER)]
        public Int32 Number
        {
            get { return number; }
            set { number = value; }
        }

        public DbClass1()
        {

        }

        public DbClass1(string way, int number)
        {
            this.way = way;
            this.number = number;
        }

        public override string ToString()
        {
            return String.Format("\"{0}\":\"{1}\",\"{2}\":\"{3}\",\"{4}\":\"{5}\"",DbClass1Schema.ID,this.Id,DbClass1Schema.WAY, this.Way, DbClass1Schema.NUMBER, this.Number);
        }
    }
}