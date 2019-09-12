using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1.Entities
{
    public class Command
    {
        private readonly List<Product> products;

        public List<Product> Products => products;

        public Command()
        {
            products = new List<Product>();
        }

        public float? GetTotal()
        {
            //Nullable float with ?
            float? result = null;

            if (this.Products.Count > 0)
            {
                result = 0;
            }

            foreach (var item in Products)
            {
                result += item.Price + (item.Price * item.Tva / 100);
            }

            return result;
        }
    }
}
