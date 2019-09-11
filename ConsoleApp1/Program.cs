using ConsoleApp1.MonProjet;
using ConsoleApp1.MonProjet.Polymorphisme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Application base namespace.
/// </summary>
namespace ConsoleApp1
{
    /// <summary>
    /// Program class for entry point.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application entry point.
        /// </summary>
        /// <param name="args">Command ligne call args retreiver.</param>
        public static void Main(string[] args)
        {
            String var = Program.ITEM_1;
            Check(var);
            StaticCheck();
            SimpleClassPolymorphism();

            Console.WriteLine("-------------------------------");
            // Cannot setup abstract class directly
            //AbstractMother mother = new AbstractMother();
            DaughterAbs1 abs1 = new DaughterAbs1();
            DaughterAbs2 abs2 = new DaughterAbs2();
            AbstractMother abs11 = new DaughterAbs1();
            // Cannot be acces
            //abs11.do4();
            (abs11 as DaughterAbs1).do4();
            Console.WriteLine("Interpret as Daughter abs1");
            abs1.do1();
            abs1.do2();
            abs1.do3();
            abs1.do4();
            Console.WriteLine("Interpret as Daughter abs2");
            abs2.do1();
            (abs2 as AbstractMother).do1();
            abs2.do2();
            abs2.do3();
            abs2.do4Bis();
            Console.WriteLine("Interpret as Mother");
            (abs1 as AbstractMother).do1();
            (abs1 as AbstractMother).do2();
            (abs1 as AbstractMother).do3();
            // Cannot be acceded
            //(abs1 as AbstractMother).do4();

            // Use new override
            abs2.MyProperty = 5;
            (abs2 as AbstractMother).MyProperty = 10;
            Console.WriteLine(abs2.MyProperty);
            Console.WriteLine((abs2 as AbstractMother).MyProperty);

            List<Interface1> listI1 = new List<Interface1>();
            listI1.Add(abs1);
            listI1.Add(abs11);
            listI1.Add(abs2);

            // var is not JS var. It only provide Interface1 items here.
            foreach (var item in listI1)
            {
                item.do5();
                item.do6();
                if (item is DaughterAbs1)
                {
                    (item as DaughterAbs1).do1();
                }
            }

            Console.ReadKey();
        }

        private static void SimpleClassPolymorphism()
        {
            Daughter daughter = new Daughter();
            daughter.MaString = "test";
            String test = daughter.MaString;

            Mother mother = new Mother();
            mother.Var1 = 1;

            // Simple cast
            ((Mother)daughter).Var1 = 10;

            // Unallowed because Daughter is under Mother
            //((Daughter)mother).Var1 = 10;
            //((Daughter)mother).MaString = "string from daughter";

            // No explicite conversion allowed
            //((String)mother).MaString = "string from daughter";

            (daughter as Mother).Var1 = 12;

            if (daughter is Mother)
            {
                Console.WriteLine("Daughter have Mother in tree");
            }

            if (daughter is Daughter)
            {
                Console.WriteLine("Daughter from Daughter class");
            }

            Console.ReadKey();
        }

        private static void StaticCheck()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine(Class1.ITEM_1);

            for (int i = 0; i < 10; i++)
            {
                Class1 item = new Class1();
            }

            //item.ITEM_1 = 10;
            Console.WriteLine(Class1.ITEM_1);
            Console.ReadKey();
        }

        public const String ITEM_1 = "Coucou";

        private static void Check(string var)
        {
            String maString = findWord(var);
            Print(maString);
        }

        private static void Print(string maString)
        {
            Console.WriteLine(maString);
            Console.ReadKey();
        }

        private static void PrintCoucou()
        {
            Console.WriteLine("coucou");
            Console.ReadKey();
        }

        private static String findWord(String baseWord)
        {
            return "\t" + baseWord + " :";
        }
    }
}
