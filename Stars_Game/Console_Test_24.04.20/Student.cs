using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Console_Test_24._04._20
{
    interface IEntity
    {
        int Id { get; set; }
    }
    internal class Student : IComparable<Student>, IEquatable<Student>, IEquatable<string>, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronimyc { get; set; }
        public int GroupId { get; set; }

        public List<int> Ratings { get; set; } = new List<int>();

        /// <summary>
        /// Вычисление среднего балла студента
        /// </summary>
        public double AverageRating
        {
            get
            {
                double result = 0d;
                foreach (double rating in Ratings)
                    result += rating;
                return result / Ratings.Count;
            }
        }
        /// <summary>
        /// Сравнение двух студентов по среднему баллу
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Student other)
        {
            var current_average_rating = AverageRating;
            var other_average_rating = other.AverageRating;

            if (Math.Abs(current_average_rating - other_average_rating) < 0.001)
                return 0;
            if (current_average_rating > other_average_rating)
                return +1;
            else
                return -1;
        }

        public bool Equals([AllowNull] Student other)
        {
            if (other == null) return false;
            return Name == other.Name && Surname == other.Surname && Patronimyc == other.Patronimyc;
        }

        /// <summary>
        /// Сравнение со строкой
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals([AllowNull] string other)
        {
            if (other == null) return false;
            return Name == other || Surname == other || Patronimyc == other;
        }
    }
}
