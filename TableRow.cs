using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Curse
{
    public class TableRow : INotifyPropertyChanged
    {
        protected int id;
        protected string model;
        protected int price;
        protected int count;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        public string Model
        {
            get { return model; }
            set { model = value; OnPropertyChanged("Model"); }
        }

        public int Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged("Price"); }
        }

        public int Count
        {
            get { return count; }
            set { count = value; OnPropertyChanged("Count"); }
        }
    }
}
