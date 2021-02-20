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

        private static void Main(string[] args)
        {
            var aircrafts = GetAircraftsFromFile("Aircrafts.json");
        }
    }
}