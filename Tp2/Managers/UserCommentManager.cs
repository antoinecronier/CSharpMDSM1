using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp2.Database;
using Tp2.Entities;

namespace Tp2.Managers
{
    public class UserCommentManager
    {
        private DbManager manager = new DbManager();

        public void Run()
        {
            CreateBaseItems();
            short? selected = ShowMenuForSelect();
            User user = manager.SqliteManager.Find<User>(selected);

            while (ShowMenuForMessages(user) != "q"){}
            ShowUserHistoric(user);
        }

        private void ShowUserHistoric(User user)
        {
            Console.WriteLine("Your historic contains");
            List <Comment> comments = manager.GetAllComment().Where(x => x.From.Id == user.Id || x.To.Id == user.Id).ToList();
            foreach (var item in comments)
            {
                Console.WriteLine("---------------");
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        private String ShowMenuForMessages(User user)
        {
            Console.WriteLine("You are logged as :\n{0} {1} {2}\n", user.Firstname, user.Lastname, user.Email);
            Console.WriteLine("Message to send");
            String message = Console.ReadLine();
            Console.WriteLine("Who need to receive message");
            short? selectedUser = ShowMenuForSelect();
            Comment comment = new Comment() { CommentAt = DateTime.Now, Data = message, From = user, To = manager.SqliteManager.Find<User>(selectedUser) };

            manager.Save(comment);

            Console.WriteLine("Quit with q");
            return Console.ReadLine();
        }

        private void CreateBaseItems()
        {
            if (!(manager.GetAllUser().Count > 0))
            {
                List<Role> roles = new List<Role>();
                for (int i = 0; i < 2; i++)
                {
                    Role role = new Role() { Name = "role" + i };
                    manager.Save(role);
                    roles.Add(role);
                }

                List<User> users = new List<User>();
                for (int i = 0; i < 3; i++)
                {
                    User user = new User() { Email = "email" + i, Firstname = "firstname" + i, Lastname = "lastname" + i, Roles = roles };
                    manager.Save(user);
                    users.Add(user);
                }

                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Comment comment = new Comment() { CommentAt=DateTime.Now, Data="data"+i+j,From=users.ElementAt(i%2),To=users.ElementAt(j%3)};
                    }
                }
            }
            
        }

        private short? ShowMenuForSelect()
        {
            short? result = null;

            Console.WriteLine("Select user to be :");

            int i = 0;
            foreach (var item in manager.GetAllUser())
            {
                Console.WriteLine("{0} : {1}", i, item.Email);
                i++;
            }

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
