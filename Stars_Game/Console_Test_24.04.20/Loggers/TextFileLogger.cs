using System;
using System.IO;

namespace Console_Test_24._04._20.Loggers
{
    internal class TextFileLogger : Logger, IDisposable
    {
        private readonly TextWriter _Writer;
        private int _Counter;

        public TextFileLogger(string FileName)
        {
            _Writer = File.CreateText(FileName);
        }

        public override void Log(string Message)
        {
            _Writer.WriteLine("{0}>{1}", _Counter++, Message);
        }

        public override void Flush()
        {
            _Writer.Flush();
        }

        public void Dispose()
        {
            _Writer.Dispose();

        }
    }
}
