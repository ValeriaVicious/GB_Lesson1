using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Test_24._04._20.Loggers
{
    internal class CombineLogger : Logger
    {

        private readonly List<Logger> _Loggers = new List<Logger>();

        public void Add(Logger logger)
        {
            _Loggers.Add(logger);
                
        }

        public override void Log(string Message)
        {
            foreach (var logger in _Loggers)
                logger.Log(Message);
        }

        public override void Flush()
        {
            foreach (var logger in _Loggers)
                logger.Flush();
        }
    }
}
