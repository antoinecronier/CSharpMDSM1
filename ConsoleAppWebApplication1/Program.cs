using ClassLibrary1;
using ConsoleAppWebApplication1.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebServiceManager<Class1> managerC1 = new WebServiceManager<Class1>("http://localhost:60984/");
            WebServiceManager<Class2> managerC2 = new WebServiceManager<Class2>("http://localhost:60984/");

            foreach (var item in managerC1.Get().Result)
            {
                Console.WriteLine(item);
            }

            foreach (var item in managerC2.Get().Result)
            {
                Console.WriteLine(item);
            }

            for (int i = 0; i < 5; i++)
            {
                Class1 class1 = new Class1() { Data = "c1B" + i };
                managerC1.Post(class1);
            }

            Console.ReadKey();
        }
    }
}
