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
using WpfApp1.Entities;

namespace WpfApp1.Navigation.UserControls
{
    /// <summary>
    /// Logique d'interaction pour UserUserControl.xaml
    /// </summary>
    public partial class UserUserControl : UserControl, INotifyPropertyChanged
    {
        //Vanilla mod
        //private User user;

        //public User User
        //{
        //    get { return user; }
        //    set {
        //        user = value;
        //        this.txtBFirstname.Text = user.Firstname;
        //        this.txtBLastname.Text = user.Lastname;
        //    }
        //}


        //public UserUserControl()
        //{
        //    InitializeComponent();
        //    this.txtBFirstname.Text = "firstname";
        //    this.txtBLastname.Text = "lastname";
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private User user;

        public User User
        {
            get { return user; }
            set {
                user = value;
                OnPropertyChanged("User");
            }
        }


        public UserUserControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
