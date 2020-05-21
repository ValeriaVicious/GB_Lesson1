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
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmployeeDB;Integrated Security=True;";
            connection = new SqlConnection(connectionString);
            dataAdapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT ID, NAME, SURNAME, SALARY, AGE, DEPARTAMENT FROM Employees", connection);
            dataAdapter.SelectCommand = command;


            //INSERT
            command = new SqlCommand(@"INSERT INTO Employees (NAME, SURNAME, SALARY, AGE, DEPARTAMENT) 
            VALUES (@NAME, @SURNAME, @SALARY, @AGE, @DEPARTAMENT); SET @ID = @@IDENTITY;", connection);
            command.Parameters.Add("@NAME", SqlDbType.NVarChar, -1, "NAME");
            command.Parameters.Add("@SURNAME", SqlDbType.NVarChar, -1, "SURNAME");
            command.Parameters.Add("@SALARY", SqlDbType.Int, 0, "SALARY");
            command.Parameters.Add("@AGE", SqlDbType.Int, 0, "AGE");
            command.Parameters.Add("@DEPARTAMENT", SqlDbType.NVarChar, -1, "DEPARTAMENT");

            SqlParameter parameter = command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
            parameter.Direction = ParameterDirection.Output;
            dataAdapter.InsertCommand = command;

            //UPDATE
            command = new SqlCommand(@"UPDATE Employees SET NAME = @NAME, SURNAME = @SURNAME, SALARY = @SALARY,
            AGE = @AGE, DEPARTAMENT = @DEPARTAMENT WHERE ID = @ID", connection);
            command.Parameters.Add("@NAME", SqlDbType.NVarChar, -1, "NAME");
            command.Parameters.Add("@SURNAME", SqlDbType.NVarChar, -1, "SURNAME");
            command.Parameters.Add("@SALARY", SqlDbType.Int, 0, "SALARY");
            command.Parameters.Add("@AGE", SqlDbType.Int, 0, "AGE");
            command.Parameters.Add("@DEPARTAMENT", SqlDbType.NVarChar, -1, "DEPARTAMENT");

            parameter = command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
            parameter.SourceVersion = DataRowVersion.Original;
            dataAdapter.UpdateCommand = command;

            //DELETE
            command = new SqlCommand("DELETE FROM Employees WHERE ID = @ID", connection);//получается, что при удалении я удаляю строку вместе с id, но не удаляю просто данные
            parameter = command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
            parameter.SourceVersion = DataRowVersion.Original;
            dataAdapter.DeleteCommand = command;
            dataTable = new DataTable();
            dataAdapter.DeleteCommand = command;
            dataAdapter.Fill(dataTable);
            WorkersDataGrid.DataContext = dataTable.DefaultView;
        }

        /// <summary> Кнопка создания/добавления данных </summary>
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


        /// <summary> Кнопка удаления данных </summary>
        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowView = (DataRowView)WorkersDataGrid.SelectedItem;
            rowView.Row.Delete();
            dataAdapter.Update(dataTable);
        }

        /// <summary> Кнопка изменения данных </summary>
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


