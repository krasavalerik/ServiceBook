using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using Microsoft.Win32;

namespace Curse
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<TableRow> Table;
        public bool isTableReverse = false;

        public MainWindow()
        {
            InitializeComponent();

            Title = "Таблица";
            Table = new ObservableCollection<TableRow>();
            table.ItemsSource = Table;
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();

            if (openDialog.ShowDialog().Value)
            {
                StreamReader sr = new StreamReader(openDialog.FileName);

                string bf = "";
                Table.Clear();

                while (!sr.EndOfStream)
                {
                    string[] line = (sr.ReadLine()).Split(';');
                    Table.Add(new TableRow { Id = int.Parse(line[0]), Model = line[1], Price = int.Parse(line[2]), Count = int.Parse(line[3]) });
                }

                sr.Close();
            }
        }

        private void DeleteSelected(object sender, RoutedEventArgs e)
        {
            var items = table.SelectedItems;
            int count = items.Count;

            for (int i = 0; i < count; i++)
            {
                TableRow row = (TableRow)items[0];
                Table.Remove(row);
            }
        }

        private void AddRow(object sender, RoutedEventArgs e)
        {
            NewRow wnd = new NewRow(Table);
            wnd.ShowDialog();
        }

        private void SaveFile(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "Table";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";

            if (dlg.ShowDialog() == true)
            {
                StreamWriter sw = new StreamWriter(dlg.FileName);

                foreach (TableRow tr in Table)
                {
                    sw.WriteLine(tr.Id + ";" + tr.Model + ";" + tr.Price + ";" + tr.Count);
                }

                sw.Close();
            }
        }

        private void EditRow(object sender, RoutedEventArgs e)
        {
            try
            {
                var itm = (TableRow)table.SelectedItem;

                var wnd = new NewRow(itm);
                wnd.Show();
            }
            catch (Exception) { }
        }

        public void Sort(object sender, RoutedEventArgs e)
        {
            int i = 0;
            object l;

            if (isTableReverse)
            {
                l = Table.Reverse();
                isTableReverse = false;

            }
            else
            {
                l = Table.OrderBy(x => x.Price);
                isTableReverse = true;
            }

            foreach (TableRow tr in (IEnumerable<TableRow>)l)
            {
                Table[i] = tr;

                i++;
            }
            Table.Reverse();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            Search wnd = new Search(Table);
            wnd.ShowDialog();
        }
    }
}


