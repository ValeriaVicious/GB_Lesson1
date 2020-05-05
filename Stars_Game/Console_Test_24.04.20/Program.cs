using Console_Test_24._04._20.Loggers;
using Console_Test_24._04._20.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Console_Test_24._04._20
{

    class Program
    {

        private const string __NamesFile = "Names.txt";

        static void Main(string[] args)
        {
            foreach (Student student in GetStudents(__NamesFile))
                Console.WriteLine(student.Surname + " " + student.Name + " " + student.Patronimyc);

            Console.ReadKey();

        }

        private static IEnumerable<Student> GetStudents(string FileName)
        {
            using (StreamReader file = File.OpenText(FileName))
            {
                while(!file.EndOfStream)
                {
                    string line = file.ReadLine();

                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] components = line.Split(' ');
                    if (components.Length != 3) continue;

                    Student student = new Student();
                    student.Surname = components[0];
                    student.Name = components[1];
                    student.Patronimyc = components[2];

                    yield return student;
                }
            }
        }

    }
}
