using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.MonProjet.Polymorphism
{
    public class Mother
    {
        //Class variable
        private int test = 1;

        #region C# property vs Java get set
        //Class variable which have a property
        private int var1;

        /// <summary>
        /// C# property equals to getter + setter from Java (use propfull snippet)
        /// </summary>
        public int Var1
        {
            get { return var1; }
            set { var1 = value; }
        }

        /// <summary>
        /// Java getter for var1
        /// </summary>
        /// <returns></returns>
        public int GetVar1()
        {
            return this.var1;
        }

        /// <summary>
        /// Java setter for var1
        /// </summary>
        /// <param name="var1"></param>
        public void SetVar1(int var1)
        {
            this.var1 = var1;
        }
        #endregion

        public void do1()
        {

        }

        protected void do2()
        {

        }

        private void do3()
        {

        }
    }
}
