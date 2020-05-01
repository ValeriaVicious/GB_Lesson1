using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Test_24._04._20.Loggers
{
    internal abstract class Logger : Ilogger
    {
        public static Logger CreateFileLogger(string FileName)
        {
            return new TextFileLogger(FileName);
        }
        public abstract void Log(string Message);


        public void LogInformation(string Message)
        {
            Log($"{DateTime.Now:s}[info:]{Message}");
        }

        public void LogWarning(string Message)
        {
            Log($"{DateTime.Now:s}[warning]:{Message}");
        }

        public void LogError(string Message)
        {
            Log($"{DateTime.Now:s}[error]:{Message}");
        }

        public virtual void Flush() { }
    }
}
