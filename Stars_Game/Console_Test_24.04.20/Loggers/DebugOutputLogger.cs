using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Test_24._04._20.Loggers
{
   internal class DebugOutputLogger : Logger
    {
        public override void Log(string Message)
        {
            System.Diagnostics.Debug.WriteLine(Message);
        }
    }
}
