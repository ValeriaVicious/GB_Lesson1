using System;

namespace Console_Test_24._04._20
{
    internal class FixPay : Workers
    {
        public FixPay(string name, double salary) : base(name, salary)
        {
            Salary = salary;

        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public override void СountingPay()
        {

        }


    }
}
