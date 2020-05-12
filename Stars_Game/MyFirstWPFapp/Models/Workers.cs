using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWPFapp.Models
{
    internal class Workers : INotifyPropertyChanged
    {
        private string _Name;
        private string _Surname;
        private int _Id;
        private int _Age;
        private int _Salary;


        public Departaments Departaments { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public int Salary
        {
            get => _Salary;
            set
            {
                if (_Salary == value) return;
                _Salary = value;
                PropertyChanged?.Invoke(this, new
                    PropertyChangedEventArgs(nameof(Salary)));
            }
        }

        public int Id
        {
            get => _Id;
            set
            {
                if (_Id == value) return;
                _Id = value;
                PropertyChanged?.Invoke(this, new
                    PropertyChangedEventArgs(nameof(Id)));
            }

        }
        public int Age
        {
            get => _Age;
            set
            {
                if (_Age == value) return;
                _Age = value;
                PropertyChanged?.Invoke(this, new
                    PropertyChangedEventArgs(nameof(Age)));
            }
        }

        public string Name
        {
            get => _Name;
            set
            {
                if (_Name == value) return;
                _Name = value;
                PropertyChanged?.Invoke(this, new
                    PropertyChangedEventArgs(nameof(Name)));
            }
        }

        public string Surname
        {
            get => _Surname;
            set
            {
                if (_Surname == value) return;
                _Surname = value;
                PropertyChanged?.Invoke(this, new
                    PropertyChangedEventArgs(nameof(Surname)));
            }
        }
    }

}

