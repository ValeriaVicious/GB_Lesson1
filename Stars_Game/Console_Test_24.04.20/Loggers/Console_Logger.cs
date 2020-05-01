using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Test_24._04._20.Loggers
{
    class Console_Logger : Logger
    {
        public override void Log(string Message)
        {
            Console.WriteLine(Message);
        }
    }
}
