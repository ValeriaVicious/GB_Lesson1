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

            var decanat = new Decanat();

            Random rnd = new Random();

            for (int i = 1; i < 10; i++)
                decanat.Add(new Student
                {
                    Name = $"Имя студента {1}",
                    Surname = $"Фамилия студента {i}",
                    Patronimyc = $"Отчество студента {i}"

                });


            var student_to_remove = decanat[0];
            decanat.Remove(student_to_remove);


            Console.ReadKey();

        }

    }
}
