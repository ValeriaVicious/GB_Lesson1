using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public int Salary { get; set; }

            public override string ToString()
            {
                return $"{Id}\t{Name}\t{Age}\t{Salary}";
            }
        }

        public class Departament
        {
            public string Name { get; set; }
            public int Number { get; set; }

            public override string ToString()
            {
                return $"{Name}\t{Number}";
            }
        }

        ObservableCollection<Employee> items = new ObservableCollection<Employee>();
        ObservableCollection<Departament> departaments = new ObservableCollection<Departament>();
        public MainWindow()
        {
            InitializeComponent();
            FillList();
            FillComboBox();
        }

        void FillComboBox()
        {
            departaments.Add(new Departament() { Number = 1, Name = "Департамент по делам кошачьих лапок" });
            departaments.Add(new Departament() { Number = 2, Name = "Департамент по делам пустых мисок" });
            departaments.Add(new Departament() { Number = 3, Name = "Департамент по делам с незаконным\nупотреблением валерьянки " });
            lbDepartament.ItemsSource = departaments;
        }
        void FillList()
        {
            items.Add(new Employee() { Id = 1, Name = "Кевин", Age = 22, Salary = 3000 });
            items.Add(new Employee() { Id = 2, Name = "Маркус", Age = 28, Salary = 5000 });
            items.Add(new Employee() { Id = 3, Name = "Джейк", Age = 35, Salary = 6000 });
            lbEmployee.ItemsSource = items;

        }

        private void lbEmployee_Selected(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(e.Source.ToString());
        }

        private void lbEmployee_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            MessageBox.Show($"Этот сотрудник работает в " + departaments[0].ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            items.Add(new Employee() { Id = 4, Name = "Питер", Age = 35, Salary = 7000 });
        }

        private void Button_Click_dep(object sender, RoutedEventArgs e)
        {
            departaments.Add(new Departament() { Number = 4, Name = "Департамент по закупкам игрушек" });
        }
    }
}
