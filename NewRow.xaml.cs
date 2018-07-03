using System.Collections.ObjectModel;
using System.Windows;

namespace Curse
{
    /// <summary>
    /// Логика взаимодействия для NewRow.xaml
    /// </summary>
    public partial class NewRow : Window
    {
        public ObservableCollection<TableRow> Table;
        public TableRow Row;

        public NewRow(ObservableCollection<TableRow> list)
        {
            InitializeComponent();

            Table = list;
            btn.Click += AddRow;
            Title = "Создание";
            btn.Content = "Создать";
        }

        public NewRow(TableRow row)
        {
            InitializeComponent();

            Row = row;
            btn.Click += EditRow;

            id.Text = row.Id.ToString();
            model.Text = row.Model.ToString();
            price.Text = row.Price.ToString();
            count.Text = row.Count.ToString();
            Title = "Редактирование";
            btn.Content = "Редактировать";
        }

        private void AddRow(object sender, RoutedEventArgs e)
        {
            Table.Add(new TableRow
            {
                Id = int.Parse(id.Text),
                Model = model.Text,
                Price = int.Parse(price.Text),
                Count = int.Parse(count.Text)
            });

            Close();
        }

        private void EditRow(object sender, RoutedEventArgs e)
        {
            Row.Id = int.Parse(id.Text);
            Row.Model = model.Text;
            Row.Price = int.Parse(price.Text);
            Row.Count = int.Parse(count.Text);
        }
    }
}