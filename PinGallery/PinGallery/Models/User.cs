using System;
using System.ComponentModel;

namespace PinGallery.Models
{
    public class User
    {
        private string _password;

        public Guid Id { get; set; }
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;

                    OnPropertyChanged("Password");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
