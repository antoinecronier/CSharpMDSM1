using ConsoleAppTP1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTP1.Managers
{
    public class SellerManager
    {
        private Command command;
        private List<Product> products;

        public SellerManager()
        {
            this.products = new List<Product>();
            this.command = new Command();
        }

        public void AddInitialProducts()
        {
            for (int i = 0; i < 10; i++)
            {
                products.Add(new PC());
            }

            for (int i = 0; i < 20; i++)
            {
                products.Add(new SmartPhone());
            }

            for (int i = 0; i < 5; i++)
            {
                products.Add(new Bike());
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
                        if (products.OfType<Bike>().Any())
                        {
                            Product product = products.OfType<Bike>().FirstOrDefault();
                            //Product product = products.Find(x => x.GetType().Name.Equals("Bike"));
                            command.Products.Add(product);
                            products.Remove(product);
                            Console.WriteLine("One more Bike added");
                        }
                        else
                        {
                            Console.WriteLine("No more Bike evailable");
                        }
                        break;
                    case 2:
                        if (products.OfType<SmartPhone>().Any())
                        {
                            Product product = products.Find(x => x.GetType().Name.Equals("SmartPhone"));
                            command.Products.Add(product);
                            products.Remove(product);
                            Console.WriteLine("One more SmartPhone added");
                        }
                        else
                        {
                            Console.WriteLine("No more SmartPhone evailable");
                        }
                        break;
                    case 3:
                        if (products.OfType<PC>().Any())
                        {
                            Product product = products.Find(x => x.GetType().Name.Equals("PC"));
                            command.Products.Add(product);
                            products.Remove(product);
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
                command.GetTotal(),
                command.Products.OfType<Bike>().Count(),
                command.Products.OfType<Bike>().Count() > 0 ? command.Products.OfType<Bike>().First().Price : (new Bike()).Price,
                command.Products.OfType<Bike>().Count() > 0 ? command.Products.OfType<Bike>().First().Tva : (new Bike()).Tva,
                command.Products.OfType<SmartPhone>().Count(),
                command.Products.OfType<SmartPhone>().Count() > 0 ? command.Products.OfType<SmartPhone>().FirstOrDefault().Price : (new SmartPhone()).Price,
                command.Products.OfType<SmartPhone>().Count() > 0 ? command.Products.OfType<SmartPhone>().FirstOrDefault().Tva : (new SmartPhone()).Tva,
                command.Products.OfType<PC>().Count(),
                command.Products.OfType<PC>().Count() > 0 ? command.Products.OfType<PC>().FirstOrDefault().Price : (new PC()).Price,
                command.Products.OfType<PC>().Count() > 0 ? command.Products.OfType<PC>().FirstOrDefault().Tva : (new PC()).Tva);
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
                command.Products.OfType<Bike>().Count(), 
                command.Products.OfType<SmartPhone>().Count(), 
                command.Products.OfType<PC>().Count());

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
