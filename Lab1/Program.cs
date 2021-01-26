using System;
using System.IO;
using Lab1.Models;
using Newtonsoft.Json;

namespace Lab1
{
    class Program
    {
        static Aircraft[] GetAircraftsFromFile(string fileName)
        {
            var fileText = File.ReadAllText(fileName);

            return JsonConvert.DeserializeObject<Aircraft[]>(fileText);
        }

        static void Main(string[] args)
        {
            Aircraft[] aircrafts = GetAircraftsFromFile("Aircrafts.json");
            
            var aircraftById = aircrafts.FindWhere(aircraft => aircraft.Id == 5);
            var yak40 = aircrafts.FindByName("Yakovlev 40");

            Console.WriteLine(aircraftById);
            Console.WriteLine(yak40);
        }
    }
}