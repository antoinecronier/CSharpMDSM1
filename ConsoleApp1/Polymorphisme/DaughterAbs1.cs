using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.MonProjet.Polymorphisme
{
    public class DaughterAbs1 : AbstractMother
    {
        public override void do2()
        {
            Console.WriteLine("do2() from DaughterAbs1");
        }

        public override void do3()
        {
            Console.WriteLine("do3() from DaughterAbs1");
        }

        public void do4()
        {
            Console.WriteLine("do4() from DaughterAbs1");
        }

        public override void do6()
        {
            Console.WriteLine("do6() from DaughterAbs1");
        }
    }
}
