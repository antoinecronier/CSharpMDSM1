using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTP1.Entities
{
    public class Bike : Product
    {
        public Bike() : base(150.00f, 12.5f)
        {
        }

        public new float Price { get { return base.Price; } }
        public new float Tva { get { return base.Tva; } }
    }
}
