using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.MonProjet.Polymorphisme
{
    public class DaughterAbs2 : AbstractMother
    {
        public new int MyProperty { get; set; }

        public new void do1()
        {
            Console.WriteLine("do1() from DaughterAbs2");
        }

        public override void do2()
        {
            Console.WriteLine("do2() from DaughterAbs2");
        }

        public void do4Bis()
        {
            Console.WriteLine("do4Bis() from DaughterAbs2");
        }

        public override void do6()
        {
            Console.WriteLine("do6() from DaughterAbs2");
        }
    }
}
