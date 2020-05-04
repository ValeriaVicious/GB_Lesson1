using Console_Test_24._04._20.Loggers;
using Console_Test_24._04._20.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Console_Test_24._04._20
{
    /// <summary>
    /// Создаем первый делегат строкового типа
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    internal delegate int StringProcessor(string str);
    internal delegate void StudentProcessor(Student student);
    class Program
    {
        private static void OnStudentsRemoved(Student student)
        {
            Console.WriteLine("Студент {0} отчислен.", student.Surname);
        }
        static void Main(string[] args)
        {

            var decanat = new Decanat();
            decanat.SubscribeToAdd(RateStudents);
            decanat.SubscribeToAdd(PrintStudents);

            decanat.ITemRemoved += OnStudentsRemoved;

            Random rnd = new Random();

            for (int i = 1; i < 10; i++)
                decanat.Add(new Student
                {
                    Name = $"Имя студента {i}",
                    Surname = $"Фамилия студента {i}",
                    Patronimyc = $"Отчество студента {i}",
                    /*Ratings = rnd.GetValues(rnd.Next(20, 30), 3, 6)*/
                });

            /*foreach (Student student in decanat)
            {
                Console.WriteLine(student.Name);
            }*/

            Student student_to_remove = decanat[0];
            decanat.Remove(student_to_remove);

            Student random_student = new Student { Surname = rnd.GetValue("Иванов", "Шевцов", "Седых", "Гриченко", "Рыбкин") };
            /*var random_rating = rnd.GetValue<int>(2, 3, 4, 5);*/

            decanat.SaveToFile("decanat.csv");
            Decanat decanat2 = new Decanat();
            decanat2.LoadFromFile("decanat.csv");

            //Создали делегат, который принимает в значение метод
            StringProcessor str_processor = new StringProcessor(GetStringLength);
            int length = str_processor("Hey, Ho, Lets GO!");

            /*StudentProcessor process = new StudentProcessor(PrintStudents);
            process(random_student);
            process = RateStudents;//пример, как можно написать, вместо new
            process(random_student);
            process = PrintStudents;
            process(random_student);*/

            ProcessStudents(decanat2, RateStudents);
            ProcessStudents(decanat2, PrintStudents);

            Decanat decanat3 = new Decanat();
            ProcessStudents(decanat2, decanat3.Add);//где-то ошибка, список не реализуется

            Console.ReadKey();

        }

        private static int GetStringLength(string str)
        {
            return str.Length;
        }

        private static void PrintStudents(Student student)
        {
            Console.WriteLine("[{0}] {1} {2} {3} - {4}", student.Id, student.Surname,
                student.Name, student.Patronimyc, student.AverageRating);//исключение из-за некорректного формата входящей строки//проблема решена, синтаксическая ошибка
        }

        private static void RateStudents(Student student)
        {
            Random rnd = new Random();
            student.Ratings.AddRange(rnd.GetValues(5, 2, 6));
        }


        private static void ProcessStudents(IEnumerable<Student> students, StudentProcessor studentProcessor)
        {
            foreach (Student student in students)
                studentProcessor(student);
        }
    }
}
