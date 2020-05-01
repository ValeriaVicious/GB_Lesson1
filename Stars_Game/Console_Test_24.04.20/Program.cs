using Console_Test_24._04._20.Loggers;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Console_Test_24._04._20
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Logger log = new DebugOutputLogger();*/
            /*Logger log = new Console_Logger();*/
            /*Logger log = new TextFileLogger("text.log");*/
            /*Logger log = new TraceLogger();*/

            /*Trace.Listeners.Add(new TextWriterTraceListener("logger.log"));
            Trace.Listeners.Add(new XmlWriterTraceListener("logger.log.xml"));

            CombineLogger combine_log = new CombineLogger();
            combine_log.Add(new Console_Logger());
            combine_log.Add(new DebugOutputLogger());
            combine_log.Add(new TraceLogger());
            combine_log.Add(new TextFileLogger("new_log.log"));

            Ilogger log = combine_log;
            combine_log.LogInformation("Message1");
            combine_log.LogWarning("Info Message");
            combine_log.LogError("Error message");

            
            using(var file_logger = new TextFileLogger("hello.log"))
            {
                file_logger.LogInformation("hello");
            }

            

            combine_log.Flush();*/

            var list = new List<Workers>
            {
                new FixPay("Джон", 7000),
                new FixPay("Энтони", 5200),
                new FixPay("Сьюзен", 8500)

            };

            list.Sort();
            foreach(var workers in list)
            {
                Console.WriteLine(workers);
            }

            Console.ReadKey();
        }

        /*private static double ComputerLongDataValue(int Count, Ilogger Log)
        {
            var result = 0;
            for (int i = 0; i < Count; i++)
            {
                result++;
                Log.Log($"Вычисление итерации {i}");
                System.Threading.Thread.Sleep(100);
            }
            return result;
        }*/
    }

}
