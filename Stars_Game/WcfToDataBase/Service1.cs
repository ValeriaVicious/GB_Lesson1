using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfToDataBase
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service1 : IService1
    {
        SqlConnection connection;
        SqlDataAdapter dataAdapter;
        DataTable dataTable;
        SqlCommand command;
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmployeeDB;Integrated Security=True;";

        void ConnectToDataBase()
        {
            connection = new SqlConnection(connectionString);
            dataAdapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT ID, NAME, SURNAME, SALARY, AGE, DEPARTAMENT FROM Employees", connection);
            dataAdapter.SelectCommand = command;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public int InsertEmployee(Employee employee)
        {
            try
            {
                command.CommandText = @"INSERT INTO Employees (NAME, SURNAME, SALARY, AGE, DEPARTAMENT";
                command.Parameters.AddWithValue("@NAME", employee.Name);
                command.Parameters.AddWithValue("@SURNAME", employee.Surname);
                command.Parameters.AddWithValue("@SALARY", employee.Salary);
                command.Parameters.AddWithValue("@AGE", employee.Age);
                command.Parameters.AddWithValue("@DEPARTAMENT", employee.Departament);
                command.Parameters.AddWithValue("@ID", employee.Id);

                command.CommandType = CommandType.Text;
                connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if(command != null)
                {
                    connection.Close();
                }
            }
        }
    }
}
