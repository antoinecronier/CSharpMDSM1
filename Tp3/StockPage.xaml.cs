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
    /// Logique d'interaction pour StockPage.xaml
    /// </summary>
    public partial class StockPage : Page, INotifyPropertyChanged
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

        private int nbPC;

        public int NbPC
        {
            get { return nbPC; }
            set {
                nbPC = value;
                OnPropertyChanged("NbPC");
            }
        }

        private int nbSmartPhone;

        public int NbSmartPhone
        {
            get { return nbSmartPhone; }
            set {
                nbSmartPhone = value;
                OnPropertyChanged("NbSmartphone");
            }
        }

        private int nbBike;

        public int NbBike
        {
            get { return nbBike; }
            set {
                nbBike = value;
                OnPropertyChanged("NbBike");
            }
        }

        public StockPage()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private MainWindow baseWindow;

        public MainWindow BaseWindow
        {
            get { return baseWindow; }
            set {
                baseWindow = value;
                this.NbPC = baseWindow.SellerManager.Products.OfType<PC>().Count();
                this.NbSmartPhone = baseWindow.SellerManager.Products.OfType<SmartPhone>().Count();
                this.NbBike = baseWindow.SellerManager.Products.OfType<Bike>().Count();
            }
        }

        private void MorePc(object sender, RoutedEventArgs e)
        {
            this.BaseWindow.SellerManager.Products.Add(new PC());
            NbPC++;
        }

        private void LessPc(object sender, RoutedEventArgs e)
        {
            if (this.BaseWindow.SellerManager.Products.OfType<PC>().Count() > 0)
            {
                this.BaseWindow.SellerManager.Products.Remove(this.BaseWindow.SellerManager.Products.OfType<PC>().First());
                NbPC--;
            }
        }

        private void MoreSmartPhone(object sender, RoutedEventArgs e)
        {
            this.BaseWindow.SellerManager.Products.Add(new SmartPhone());
            NbSmartPhone++;
        }

        private void LessSmartphone(object sender, RoutedEventArgs e)
        {
            if (this.BaseWindow.SellerManager.Products.OfType<SmartPhone>().Count() > 0)
            {
                this.BaseWindow.SellerManager.Products.Remove(this.BaseWindow.SellerManager.Products.OfType<SmartPhone>().First());
                NbSmartPhone--;
            }
        }

        private void MoreBike(object sender, RoutedEventArgs e)
        {
            this.BaseWindow.SellerManager.Products.Add(new Bike());
            NbBike++;
        }

        private void LessBike(object sender, RoutedEventArgs e)
        {
            if (this.BaseWindow.SellerManager.Products.OfType<Bike>().Count() > 0)
            {
                this.BaseWindow.SellerManager.Products.Remove(this.BaseWindow.SellerManager.Products.OfType<Bike>().First());
                NbBike--;
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            AccueilPage page = new AccueilPage();
            page.BaseWindow = this.BaseWindow;
            this.BaseWindow.Content = page;
        }
    }
}
