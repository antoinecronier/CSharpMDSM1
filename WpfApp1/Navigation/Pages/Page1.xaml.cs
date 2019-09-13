using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.Navigation.Pages
{
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Window BaseWindow { get; set; }

        public Page1()
        {
            InitializeComponent();
            Loaded += Page1_Loaded;
        }

        private void Page1_Loaded(object sender, RoutedEventArgs e)
        {
            this.UserUserControl.User = new Entities.User() { Firstname = "jean", Lastname = "michel" };
            Task.Factory.StartNew(()=>
            {
                while (true)
                {
                    Task.Delay(TimeSpan.FromSeconds(2));
                    this.UserUserControl.User.Firstname += "a";
                    //Vanilla call not working in async state
                    //this.UserUserControl.txtBFirstname.Text += "a";
                }
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //(this.Parent as Window).Content = new Page2();
            Page2 page2 = new Page2();
            page2.BaseWindow = this.BaseWindow;
            this.BaseWindow.Content = page2;
        }
    }
}
