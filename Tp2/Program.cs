using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp2.Database;
using Tp2.Entities;
using Tp2.Managers;

namespace Tp2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UserCommentManager manager = new UserCommentManager();
            manager.Run();
        }
    }
}
