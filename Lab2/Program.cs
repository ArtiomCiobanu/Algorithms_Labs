using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lab1.Models;
using Newtonsoft.Json;

namespace Lab2
{
    internal class Program
    {
        private static Aircraft[] GetAircraftsFromFile(string fileName)
        {
            var fileText = File.ReadAllText(fileName);

            return JsonConvert.DeserializeObject<Aircraft[]>(fileText);
        }

        private static void Main()
        {
            //BubbleSort();
            QuickSortV4();
        }

        public static void BubbleSort()
        {
            var aircrafts = GetAircraftsFromFile("Aircrafts.json");

            for (int f = 0; f < aircrafts.Length - 1; f++)
            {
                for (int i = 0; i < aircrafts.Length - 1; i++)
                {
                    if (aircrafts[i].Price > aircrafts[i + 1].Price)
                    {
                        var swapper = aircrafts[i];
                        aircrafts[i] = aircrafts[i + 1];
                        aircrafts[i + 1] = swapper;
                    }
                }
            }

            foreach (var t in aircrafts)
            {
                Console.WriteLine(t);
            }
        }

        public static void QuickSortV4()
        {
            var aircrafts = GetAircraftsFromFile("Aircrafts.json");

            int lastIndex = aircrafts.Length - 1;

            var areas = new List<Tuple<int, int>>
            {
                new(0, lastIndex)
            };

            while (areas.Any())
            {
                var (left, right) = areas.First();
                
                var pivotIndex = (right + left) / 2;
                var pivot = aircrafts[pivotIndex];

                for (int i = pivotIndex - 1; i >= left; i--)
                {
                    if (aircrafts[i].Price > pivot.Price)
                    {
                        var current = aircrafts[i];
                        //Сдвиг всего влево
                        for (int j = i; j < right - 1; j++)
                        {
                            aircrafts[j] = aircrafts[j + 1];
                        }

                        aircrafts[right - 1] = current;

                        pivotIndex--;
                    }
                }

                for (int i = pivotIndex + 1; i < right; i++)
                {
                    if (aircrafts[i].Price < pivot.Price)
                    {
                        var current = aircrafts[i];

                        for (int j = i; j >= left + 1; j--)
                        {
                            aircrafts[j] = aircrafts[j - 1];
                        }

                        aircrafts[left] = current;

                        pivotIndex++;
                    }
                }


                areas.RemoveAt(0);
                if (right - pivotIndex > 1)
                {
                    var area2 = new Tuple<int, int>(pivotIndex, right);
                    areas.Insert(0, area2);
                }

                if (pivotIndex - left > 1)
                {
                    var area1 = new Tuple<int, int>(left, pivotIndex);
                    areas.Insert(0, area1);
                }
            }

            foreach (var t in aircrafts)
            {
                Console.WriteLine(t);
            }
        }
    }
}