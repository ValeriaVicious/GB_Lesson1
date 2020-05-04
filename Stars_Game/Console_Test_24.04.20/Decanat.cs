using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Console_Test_24._04._20
{
    internal class Decanat : EntityStorage<Student>
    {
        /// <summary>
        /// Запись всех студентов в файл построчно
        /// </summary>
        /// <param name="FileName"></param>
        public override void SaveToFile(string FileName)
        {
            using (StreamWriter file_writer = File.CreateText(FileName))
                foreach (var student in this)
                {
                    file_writer.WriteLine(string.Join(",", student.Surname,
                        student.Name, student.Patronimyc, string.Join(";", student.Ratings)));
                }

        }

        /// <summary>
        /// Чтение файла построчно считывая одну строку из файла
        /// </summary>
        /// <param name="FileName"></param>
        public override void LoadFromFile(string FileName)
        {

            using (StreamReader file_reader = File.OpenText(FileName))
                while (file_reader.EndOfStream)
                {
                    string str = file_reader.ReadLine();

                    if (string.IsNullOrWhiteSpace(str)) continue;

                    string[] components = str.Split(',');
                    Student student = new Student
                    {
                        Surname = components[0],
                        Name = components[1],
                        Patronimyc = components[2],
                        
                    };

                    string[] ratings = components[3].Split(';');
                    foreach (string rating in ratings)
                        student.Ratings.Add(int.Parse(rating));

                    Add(student);
                }
        }
    }

    /// <summary>
    /// Описание абстрактного класса, который наследуется от предыдущего, передавая
    /// свой параметр. Тип может быть как классом так и структурой(обозначить после where).
    /// С помощью этого можно задавать свои ограничения
    /// </summary>
    /// <typeparam name="IEntity"></typeparam>
    internal abstract class EntityStorage<TEntity> : Storage<TEntity>
        where TEntity : IEntity
    {
        private int _MaxId = 1;
        public override void Add(TEntity item)
        {
            item.Id = _MaxId++;
            base.Add(item);
        }
    }
}
