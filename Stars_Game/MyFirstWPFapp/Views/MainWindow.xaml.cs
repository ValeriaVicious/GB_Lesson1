using MyFirstWPFapp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
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


namespace MyFirstWPFapp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection;
        SqlDataAdapter dataAdapter;
        DataTable dataTable;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            DataRow newRow = dataTable.NewRow();
            EditWindow editWindow = new EditWindow(newRow);
            editWindow.ShowDialog();

            if (editWindow.DialogResult.HasValue && editWindow.DialogResult.Value)
            {
                dataTable.Rows.Add(editWindow.resultRow);
                dataAdapter.Update(dataTable);
            }

            else newRow.CancelEdit();
        }


        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowView = (DataRowView)WorkersDataGrid.SelectedItem;
            rowView.Row.Delete();
            dataAdapter.Update(dataTable);
        }

        private void changeBtn_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowView = (DataRowView)WorkersDataGrid.SelectedItem;
            rowView.BeginEdit();
            EditWindow editWindow = new EditWindow(rowView.Row);
            editWindow.ShowDialog();

            if (editWindow.DialogResult.HasValue && editWindow.DialogResult.Value)
            {
                rowView.EndEdit();
                dataAdapter.Update(dataTable);
            }

            else rowView.CancelEdit();
        }
    }
}


