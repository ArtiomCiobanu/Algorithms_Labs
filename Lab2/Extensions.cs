using System;
using System.Collections.Generic;

namespace Lab2
{
    public static class Extensions
    {
        public static void Display<T>(this IEnumerable<T> collection)
        {
            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine();
        }
    }
}