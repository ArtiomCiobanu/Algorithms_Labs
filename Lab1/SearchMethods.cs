﻿using System;
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

        public static Aircraft BinarySearchPrice(this Aircraft[] collection, int price)
        {
            int leftIndex = 0;
            int rightIndex = collection.Length - 1;

            while (collection[leftIndex].Price != price)
            {
                var middle = (int) Math.Round((leftIndex + rightIndex) / 2.0);

                if (collection[middle].Price > price)
                {
                    rightIndex = middle;
                }
                else
                {
                    leftIndex = middle;
                }
            }

            return collection[leftIndex];
        }

        public static Aircraft InterpolationSearch(this Aircraft[] collection, int price)
        {
            int leftIndex = 0;
            int rightIndex = collection.Length - 1;

            double leftValue = collection[leftIndex].Price;
            double rightValue = collection[rightIndex].Price;

            while (leftIndex < rightIndex &&
                   leftValue <= price && price <= rightValue)
            {
                int m = (int) Math.Ceiling(leftIndex +
                                           (price - leftValue) * (rightIndex - leftIndex) /
                                           (rightValue - leftValue));

                if (price > leftValue)
                {
                    leftIndex = m + 1;
                }
                else
                {
                    rightIndex = m - 1;
                }

                leftValue = collection[leftIndex].Price;
                rightValue = collection[rightIndex].Price;
            }

            return collection[leftIndex];
        }
    }
}