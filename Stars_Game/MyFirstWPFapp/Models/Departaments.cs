using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWPFapp.Models
{
    class Departaments
    {
        public class Departament
        {
            public string Name { get; set; }
            public int Number { get; set; }

            public override string ToString()
            {
                return $"{Name}\t{Number}";
            }
        }

        void FillComboBox()
        {
            //departaments.Add(new Departament() { Number = 1, Name = "Департамент по делам кошачьих лапок" });
            //departaments.Add(new Departament() { Number = 2, Name = "Департамент по делам пустых мисок" });
            //departaments.Add(new Departament() { Number = 3, Name = "Департамент по делам с незаконным\nупотреблением валерьянки " });
            ////lbDepartament.ItemsSource = departaments;
        }

    }
}
