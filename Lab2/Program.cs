using System;
using System.IO;
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
            BubbleSort();
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
    }
}