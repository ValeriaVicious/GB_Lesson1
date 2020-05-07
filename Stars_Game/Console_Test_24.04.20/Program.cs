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

        /*2. Дана коллекция List<T>, требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции:

        а) для целых чисел;
        б) *для обобщенной коллекции;*/


        public static Dictionary<int, int> myDictionary1(List<int> s)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            foreach (int i in s)
            {
                if (!dictionary.ContainsKey(i))
                    dictionary.Add(i, 1);
                else
                    dictionary[i]++;
            }
            return dictionary;
        }

        public static Dictionary<T, int> myDictionary2<T, value>(List<T> s)
        {
            Dictionary<T, int> dictionary = new Dictionary<T, int>();
            foreach (T i in s)
            {
                if (!dictionary.ContainsKey(i))
                    dictionary.Add(i, 1);
                else
                    dictionary[i]++;
            }
            return dictionary;
        }


        static void Main()
        {
            List<string> str_list = new List<string>() { "fox", "bear", "dog", "cat" };
            myDictionary2<string, int>(str_list);
            
            List<int> integer_list = new List<int>() { 1, 22, 3, 42, 5, 22, 9, 5, 36, 74 };
            myDictionary1(integer_list);

            Console.ReadKey();

        }
    }
}
