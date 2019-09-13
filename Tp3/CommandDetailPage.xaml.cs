using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Tp1.Entities;

namespace Tp3
{
    /// <summary>
    /// Logique d'interaction pour CommandDetailPage.xaml
    /// </summary>
    public partial class CommandDetailPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public CommandDetailPage()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private MainWindow baseWindow;

        public MainWindow BaseWindow
        {
            get { return baseWindow; }
            set {baseWindow = value;}
        }
        
        private Command command;

        public Command Command
        {
            get { return command; }
            set {
                command = value;
                this.itemsList.ItemsSource = command.Products;
                //List<Product> products = new List<Product>();
                //products.Add(new PC());
                //products.Add(new Bike());
                //products.Add(new SmartPhone());
                //this.itemsList.ItemsSource = products;
                OnPropertyChanged("Command");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AccueilPage page = new AccueilPage();
            page.BaseWindow = this.BaseWindow;
            this.BaseWindow.Content = page;
        }
    }
}
