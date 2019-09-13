using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour AccueilPage.xaml
    /// </summary>
    public partial class AccueilPage : Page
    {
        private MainWindow baseWindow;

        public MainWindow BaseWindow
        {
            get { return baseWindow; }
            set {
                baseWindow = value;
                foreach (var item in baseWindow.SellerManager.Commands)
                {
                    commands.Add(item);
                }
            }
        }

        ObservableCollection<Command> commands = new ObservableCollection<Command>();

        public AccueilPage()
        {
            InitializeComponent();
            this.itemsList.ItemsSource = commands;
            this.itemsList.SelectionChanged += ItemsList_SelectionChanged;
        }

        private void ItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Command item = null;
            if (e.AddedItems.Count > 0)
            {
                foreach (var test in e.AddedItems)
                {
                    item = test as Command;
                }
                if (item != null)
                {
                    CommandDetailPage page = new CommandDetailPage();
                    page.BaseWindow = this.BaseWindow;
                    page.Command = item;
                    this.BaseWindow.Content = page;
                }
            }
        }

        private void ShowStock(object sender, RoutedEventArgs e)
        {
            StockPage page = new StockPage();
            page.BaseWindow = this.BaseWindow;
            this.BaseWindow.Content = page;
        }

        private void CreateCommand(object sender, RoutedEventArgs e)
        {
            CommandMakePage page = new CommandMakePage();
            page.BaseWindow = this.BaseWindow;
            this.BaseWindow.Content = page;
        }
    }
}
