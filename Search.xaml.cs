using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Curse
{
    /// <summary>
    /// Логика взаимодействия для Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        public ObservableCollection<TableRow> Table;

        public Search()
        {
            InitializeComponent();
            Title = "Поиск элемента";
        }

        public Search(ObservableCollection<TableRow> list)
        {
            InitializeComponent();

            Table = list;
            table.ItemsSource = Table;
        }

        private void Find(object sender, RoutedEventArgs e)
        {
            var res = (IEnumerable<TableRow>)Table;

            if (this.id.Text.Length > 0)
            {
                int id = int.Parse(this.id.Text);
                res = res.Where(x => x.Id == id);
            }

            if (this.model.Text.Length > 0)
            {
                string model = this.model.Text;
                res = res.Where(x => x.Model == model);
            }

            if (this.price.Text.Length > 0)
            {
                int price = int.Parse(this.price.Text);
                res = res.Where(x => x.Price == price);
            }

            if (this.count.Text.Length > 0)
            {
                int count = int.Parse(this.count.Text);
                res = res.Where(x => x.Count == count);
            }

            table.ItemsSource = res;
        }
        
    }
}
