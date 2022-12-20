using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace StashApp
{
    public class ItemBindable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string name;
        string expireDate;

        public string Name
        {
            set
            {
                if (!value.Equals(name, StringComparison.Ordinal))
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
            get
            {
                return name;
            }
        }
        public string ExpirationDate
        {
            set
            {
                if (!value.Equals(expireDate, StringComparison.Ordinal))
                {
                    expireDate = value;
                    OnPropertyChanged("expireDate");
                }
            }
            get
            {
                return expireDate;
            }
        }
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
