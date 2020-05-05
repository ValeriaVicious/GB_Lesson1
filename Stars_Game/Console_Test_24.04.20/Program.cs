using Console_Test_24._04._20.Loggers;
using Console_Test_24._04._20.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Linq;

namespace Console_Test_24._04._20
{

    class Program
    {

        private const string __NamesFile = "Names.txt";

        static void Main(string[] args)
        {
            foreach (Student student in GetStudents(__NamesFile))
                Console.WriteLine(student.Surname + " " + student.Name + " " + student.Patronimyc);

            List<Student> student_list = new List<Student>(100);

            int id = 1;

            foreach (Student student in GetStudents(__NamesFile))
            {
                student.Id = id++;
                student_list.Add(student);

            }

            /*student_list.RemoveAt(4);
            *//*
                        //Отсортировали по возрастанию фамилии
                        student_list.Sort((s1, s2) => StringComparer.Ordinal.Compare(s1.Surname, s2.Surname));

                        //Отсортировали по убыванию имени
                        student_list.Sort((s1, s2) => StringComparer.Ordinal.Compare(s2.Name, s1.Name));*/
            /*student_list.Clear();

            student_list.AddRange(GetStudents(__NamesFile));

            Student[] students_array = student_list.ToArray();

            Dictionary<string, List<Student>> surename_students = new Dictionary<string, List<Student>>();
            surename_students.Add("qwe", new List<Student>());*/

            IEnumerable<Student> students = GetStudents(__NamesFile);

            Console.ReadKey();

        }

        private static IEnumerable<Student> GetStudents(string FileName)
        {
            Random rnd = new Random();
            
            using (StreamReader file = File.OpenText(FileName))
            {
                while (!file.EndOfStream)
                {
                    string line = file.ReadLine();

                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] components = line.Split(' ');
                    if (components.Length != 3) continue;

                    Student student = new Student();
                    student.Surname = components[0];
                    student.Name = components[1];
                    student.Patronimyc = components[2];
                    student.Ratings = rnd.GetValues(20, 2, 6);

                    yield return student;
                }
            }
        }

    }
}
