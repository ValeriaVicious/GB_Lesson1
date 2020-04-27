using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Test_24._04._20
{
    /// <summary>Объект, который поддерживает возможность операций логгирования</summary>
    internal interface Ilogger
    {
        /// <summary>Добавление сообщения в журнал </summary>
        /// <param name="Message"></param>
        void Log(string Message);

        /*/// <summary> Добавление сообщения об информации</summary>
        /// <param name="Message"></param>
        void LogInformation(string Message);

        /// <summary>Сообщение о предупреждении </summary>
        /// <param name="Message"></param>
        void LogWarning(string Message);

        /// <summary>Сообщение об ошибке</summary>
        /// <param name="Message"></param>
        void LogError(string Message);*/
        
    }
}
