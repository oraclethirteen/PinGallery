using System;
using System.ComponentModel;

namespace PinGallery.Models
{
    public class Photo
    {
        private string _name;
        private string _date;

        public Guid Id { get; set; }

        public string Name
        {
            get { return _name; }

            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Date
        {
            get { return _date; }

            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged("Date");
                }
            }
        }

        public string Image { get; set; }

        public Photo(string name = null, string image = null, string date = null)
        {
            Id = Guid.NewGuid();
            Name = name;
            Image = image;
            Date = date;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
