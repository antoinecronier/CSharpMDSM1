using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTP1.Entities
{
    public class SmartPhone : Product
    {
        public SmartPhone() : base(100.00f, 10.5f)
        {
        }

        public new float Price { get { return base.Price; } }
        public new float Tva { get { return base.Tva; } }
    }
}
