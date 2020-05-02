using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Test_24._04._20
{
   internal class Decanat : Storage<Student> 
    {
        private int _MaxId = 1;
        public override void Add(Student item)
        {
            item.Id = _MaxId++;
            base.Add(item);
        }
    }
}
