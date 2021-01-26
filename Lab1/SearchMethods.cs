using System;
using System.Collections.Generic;
using Lab1.Models;

namespace Lab1
{
    public static class SearchMethods
    {
        public static T FindWhere<T>(this IEnumerable<T> collection, Predicate<T> condition)
            where T : class
        {
            foreach (var item in collection)
            {
                if (condition(item))
                {
                    return item;
                }
            }

            return null;
        }

        public static Aircraft FindByName(this IEnumerable<Aircraft> aircrafts, string name)
            => aircrafts.FindWhere(a => a.Name == name);
    }
}