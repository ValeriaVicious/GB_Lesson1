using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileHosting
{
    public class Program
    {
        static void Main(string[] args)
        {

            Employee employee = new Employee
            {
                Name = "Employee name",
                Surname = "Employee surname",
                Birthday = DateTime.Now
            };


            BinaryFormatter formatter = new BinaryFormatter();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));

            using (FileStream bin_file = File.Create("employee.bin"))
            using (FileStream xml_file = File.Create("employee.xml"))
            {
                formatter.Serialize(bin_file, employee);
                xmlSerializer.Serialize(xml_file, employee);
            }

            Employee employee1, employee2;
            using (FileStream bin_file = File.Open("employee.bin", FileMode.Open))
            using (FileStream xml_file = File.Open("employee.xml", FileMode.Open))
            {
                employee1 = (Employee)formatter.Deserialize(bin_file);
                employee2 = (Employee)xmlSerializer.Deserialize(xml_file);
            }

        }

        [Serializable]
        public class Employee
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime Birthday { get; set; }
        }
    }
}
