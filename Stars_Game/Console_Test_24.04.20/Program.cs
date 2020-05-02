using Console_Test_24._04._20.Loggers;
using Console_Test_24._04._20.Service;
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
                    Name = $"Имя студента {i}",
                    Surname = $"Фамилия студента {i}",
                    Patronimyc = $"Отчество студента {i}",
                    Ratings = rnd.GetValues(rnd.Next(20, 30), 3, 6)
                });

            foreach (Student student in decanat)
            {
                Console.WriteLine(student.Name);
            }

            Student student_to_remove = decanat[0];
            decanat.Remove(student_to_remove);

            Student random_student = new Student { Name = rnd.GetValue("Иванов", "Шевцов", "Седых", "Гриченко", "Рыбкин") };
            var random_rating = rnd.GetValue<int>(2, 3, 4, 5);

            decanat.SaveToFile("decanat.csv");
            Decanat decanat2 = new Decanat();
            decanat2.LoadFromFile("decanat.csv");
            
            Console.ReadKey();

        }

    }
}
