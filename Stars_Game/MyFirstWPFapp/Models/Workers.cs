using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWPFapp.Models
{
    class Workers
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

        //ObservableCollection<Employee> items = new ObservableCollection<Employee>();

        //void FillList()
        //{
        //    items.Add(new Employee() { Id = 1, Name = "Кевин", Age = 22, Salary = 3000 });
        //    items.Add(new Employee() { Id = 2, Name = "Маркус", Age = 28, Salary = 5000 });
        //    items.Add(new Employee() { Id = 3, Name = "Джейк", Age = 35, Salary = 6000 });
        //    lbEmployee.ItemsSource = items;

        //}
    }
}
