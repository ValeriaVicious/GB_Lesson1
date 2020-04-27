using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Test_24._04._20
{
    internal abstract class Workers : IComparable<Workers>
    {

        public string Name { get; set; }
        public double Salary { get; set; }
       
        public abstract void СountingPay();
        public abstract int CompareTo(object obj);


        public Workers(string name, double salary)
        {
            Salary = salary;
            Name = name;
            
        }

        public int CompareTo(Workers workers)
        {
            var result = Salary.CompareTo(workers.Salary);
            if (result == 0)
                result = Name.CompareTo(workers.Name);
            return result;
        }
        public override string ToString()
        {
            return Salary + " " + Name;
        }


    }


}
