using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Test_24._04._20.Loggers
{
   internal class HourPay : Workers
    {
        public double HourSalary { get; set; }
        public HourPay( string name, double hourSalary):base (name, hourSalary)
        {
            HourSalary = hourSalary;


        }

        public override void СountingPay()
        {
            Salary = 20.8 * 8 * HourSalary;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

       
    }
}
