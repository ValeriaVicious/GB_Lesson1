using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace MyFirstWPFapp.Views
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public DataRow resultRow { get; set; }

        public EditWindow(DataRow dataRow)
        {
            InitializeComponent();
            resultRow = dataRow;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NameTxtBox.Text = resultRow["Name"].ToString();
            SurnameTxtBox.Text = resultRow["Surname"].ToString();
            DepartamentTxtBox.Text = resultRow["Departament"].ToString();
            SalaryTxtBox.Text = resultRow["Salary"].ToString();
            AgeTxtBox.Text = resultRow["Age"].ToString();

        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            resultRow["Name"] = NameTxtBox.Text;
            resultRow["Surname"] = SurnameTxtBox.Text;
            resultRow["Departament"] = DepartamentTxtBox.Text;
            resultRow["Salary"] = SalaryTxtBox.Text;
            resultRow["Age"] = AgeTxtBox.Text;
            DialogResult = true;
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}


