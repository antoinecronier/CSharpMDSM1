﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Entities
{
    public class User : INotifyPropertyChanged
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

        private String firstname;

        public String Firstname
        {
            get { return firstname; }
            set {
                firstname = value;
                OnPropertyChanged("Firstname");
            }
        }

        private String lastname;

        public String Lastname
        {
            get { return lastname; }
            set {
                lastname = value;
                OnPropertyChanged("Lastname");
            }
        }

    }
}
