using System;
using System.IO;
using System.Linq;
using Lab1.BinaryTreeItems;
using Lab1.Models;
using Newtonsoft.Json;

namespace Lab1
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
            var aircrafts = GetAircraftsFromFile("Aircrafts.json");

            //Линейный поиск
            /*var aircraftById = aircrafts.FindWhere(aircraft => aircraft.Id == 5);
            var yak40 = aircrafts.FindByName("Yakovlev 40");

            Console.WriteLine(aircraftById);
            Console.WriteLine(yak40);*/

            //Поиск через бинарное дерево
            /*var tree = new BinaryTree(aircrafts.First());
            foreach (var aircraft in aircrafts)
            {
                tree.InsertValue(aircraft);
            }

            var result = tree.Find(2940).ToArray();

            Console.WriteLine(result.FirstOrDefault()?.ToString());*/

            //Двоичный поиск
            var sortedAircrafts = aircrafts.OrderBy(aircraft => aircraft.Price).ToArray();

            //var a = sortedAircrafts.BinarySearchPrice(2940);
            var air = sortedAircrafts.InterpolationSearch(2940);
            Console.WriteLine(air.ToString());
        }
    }
}