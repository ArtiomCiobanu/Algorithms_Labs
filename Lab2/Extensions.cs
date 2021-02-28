using System;
using System.Collections.Generic;
using System.Linq;
using Lab1.Models;

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

        public static void InsertBeforeHighest(this List<Aircraft> collection, Aircraft element)
        {
            int index = 0;
            for (int i = 0; i < collection.Count; i++)
            {
                index = i;

                if (element.Price < collection[i].Price)
                {
                    break;
                }

                if (i == collection.Count - 1)
                {
                    index = i + 1;
                }
            }

            collection.Insert(index, element);
        }
    }
}