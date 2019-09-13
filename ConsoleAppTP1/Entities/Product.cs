using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1.Entities
{
    public abstract class Product
    {
        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private float price;

        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        private float tva;

        public float Tva
        {
            get { return tva; }
            set { tva = value; }
        }

        public Product(float price, float tva, String name)
        {
            this.price = price;
            this.tva = tva;
            this.name = name;
        }
    }
}
