using ConsoleAppTP1.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTP1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SellerManager manager = new SellerManager();
            manager.Run();
        }
    }
}
