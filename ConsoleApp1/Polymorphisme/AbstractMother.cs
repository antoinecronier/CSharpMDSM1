using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.MonProjet.Polymorphisme
{
    public abstract class AbstractMother : Interface1
    {
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        // Cannot be override in sub-classes
        public void do1()
        {
            Console.WriteLine("do1() from AbstractMother");
        }

        public abstract void do2();

        // Can be override in sub-classes
        public virtual void do3()
        {
            Console.WriteLine("do3() from AbstractMother");
        }

        public void do5()
        {
            Console.WriteLine("do5() from AbstractMother");
        }

        public abstract void do6();
    }
}
