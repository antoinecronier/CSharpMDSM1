using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp1.Entities;

namespace Tp3
{
    public class WpfSellerManager
    {
        private Command command;
        private List<Product> products;
        private List<Command> commands;

        public WpfSellerManager()
        {
            this.Products = new List<Product>();
            this.Command = new Command();
            this.Commands = new List<Command>();
        }

        public Command Command { get => command; set => command = value; }
        public List<Product> Products { get => products; set => products = value; }
        public List<Command> Commands { get => commands; set => commands = value; }

        public void AddInitialProducts()
        {
            for (int i = 0; i < 10; i++)
            {
                Products.Add(new PC());
            }

            for (int i = 0; i < 20; i++)
            {
                Products.Add(new SmartPhone());
            }

            for (int i = 0; i < 5; i++)
            {
                Products.Add(new Bike());
            }
        }
    }
}
