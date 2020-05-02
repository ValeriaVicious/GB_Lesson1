using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Test_24._04._20.Service
{
    internal static class RandomExtensions
    {
        public static List<int> GetValues(this Random rnd, int Count, int Min, int Max)
        {
            var result = new List<int>(Count);

            for (int i = 0; i < Count; i++)
                result.Add(rnd.Next(Min, Max));

            return result;
        }
    }
}
