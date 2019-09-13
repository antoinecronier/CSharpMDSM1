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

        public void Run()
        {
            AddInitialProducts();

            short? selected;
            while ((selected = ShowMenuForSelect()) != 4)
            {
                switch (selected)
                {
                    case 1:
                        if (Products.OfType<Bike>().Any())
                        {
                            Product product = Products.OfType<Bike>().FirstOrDefault();
                            //Product product = products.Find(x => x.GetType().Name.Equals("Bike"));
                            Command.Products.Add(product);
                            Products.Remove(product);
                            Console.WriteLine("One more Bike added");
                        }
                        else
                        {
                            Console.WriteLine("No more Bike evailable");
                        }
                        break;
                    case 2:
                        if (Products.OfType<SmartPhone>().Any())
                        {
                            Product product = Products.Find(x => x.GetType().Name.Equals("SmartPhone"));
                            Command.Products.Add(product);
                            Products.Remove(product);
                            Console.WriteLine("One more SmartPhone added");
                        }
                        else
                        {
                            Console.WriteLine("No more SmartPhone evailable");
                        }
                        break;
                    case 3:
                        if (Products.OfType<PC>().Any())
                        {
                            Product product = Products.Find(x => x.GetType().Name.Equals("PC"));
                            Command.Products.Add(product);
                            Products.Remove(product);
                            Console.WriteLine("One more PC added");
                        }
                        else
                        {
                            Console.WriteLine("No more PC evailable");
                        }
                        break;
                    default:
                        Console.WriteLine("Error from selected item");
                        break;
                }
                Console.WriteLine("------------");
            }
            ShowInfoTotal();
        }

        //public void SelectOneFromList<T,K>(List<K> items, String stringItem)
        //{
        //    if (products.OfType<T>().Any())
        //    {
        //        Product product = products.Find(x => x is T);
        //        command.Products.Add(product);
        //        products.Remove(product);
        //        Console.WriteLine("One more {0} added", stringItem);
        //    }
        //    else
        //    {
        //        Console.WriteLine("No more {0} evailable", stringItem);
        //    }
        //}

        private void ShowInfoTotal()
        {
            Console.WriteLine("Your client currently have to payed {0} TTC for :" +
                "\n{1} bike(s) : unit price {2} | tva {3} " +
                "\n{4} smartphone(s) : unit price {5} | tva {6} " +
                "\n{7} PC(s) : unit price {8} | tva {9} ",
                Command.GetTotal(),
                Command.Products.OfType<Bike>().Count(),
                Command.Products.OfType<Bike>().Count() > 0 ? Command.Products.OfType<Bike>().First().Price : (new Bike()).Price,
                Command.Products.OfType<Bike>().Count() > 0 ? Command.Products.OfType<Bike>().First().Tva : (new Bike()).Tva,
                Command.Products.OfType<SmartPhone>().Count(),
                Command.Products.OfType<SmartPhone>().Count() > 0 ? Command.Products.OfType<SmartPhone>().FirstOrDefault().Price : (new SmartPhone()).Price,
                Command.Products.OfType<SmartPhone>().Count() > 0 ? Command.Products.OfType<SmartPhone>().FirstOrDefault().Tva : (new SmartPhone()).Tva,
                Command.Products.OfType<PC>().Count(),
                Command.Products.OfType<PC>().Count() > 0 ? Command.Products.OfType<PC>().FirstOrDefault().Price : (new PC()).Price,
                Command.Products.OfType<PC>().Count() > 0 ? Command.Products.OfType<PC>().FirstOrDefault().Tva : (new PC()).Tva);
            Console.ReadKey();
        }

        private short? ShowMenuForSelect()
        {
            short? result = null;

            Console.WriteLine("Select element to add :");

            Console.WriteLine("1 : Bike");
            Console.WriteLine("2 : Smartphone");
            Console.WriteLine("3 : PC");
            Console.WriteLine("4 : End");

            Console.WriteLine("Currently you have :\n{0} bike(s)\n{1} smartphone(s)\n{2} PC(s)",
                Command.Products.OfType<Bike>().Count(),
                Command.Products.OfType<SmartPhone>().Count(),
                Command.Products.OfType<PC>().Count());

            String selected = Console.ReadLine();
            short parse = 0;
            if (Int16.TryParse(selected, out parse))
            {
                result = parse;
            }

            return result;
        }
    }
}
