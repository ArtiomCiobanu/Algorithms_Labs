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

        static void Sort(int[] array)
        {
            var length = array.Length;
            for (int i = length / 2 - 1; i >= 0; i--)
            {
                Heapify(array, length, i);
            }

            array.DisplayInline();

            for (int i = length - 1; i >= 0; i--)
            {
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;
                Heapify(array, i, 0);
            }
        }

        //Rebuilds the heap
        static void Heapify(int[] array, int length, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < length && array[left] > array[largest])
            {
                largest = left;
            }

            if (right < length && array[right] > array[largest])
            {
                largest = right;
            }

            if (largest != i)
            {
                int swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;
                Heapify(array, length, largest);
            }
        }

        public static void Main()
        {
            //int[] arr = {74, 19, 24, 5, 8, 79, 42, 15, 20, 53, 11};
            //Console.WriteLine("Heap Sort");

            //arr.DisplayInline();

            //Sort(arr);

            //arr.DisplayInline();

            Console.WriteLine();

            //BubbleSort();
            //QuickSort();
            //SelectionSort();
            //ShellSort();
            //MergeSort();

            HeapSort();
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

            aircrafts.Display();
        }

        public static void QuickSort()
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

            aircrafts.Display();
        }

        public static void SelectionSort()
        {
            var aircrafts = GetAircraftsFromFile("Aircrafts.json");

            for (int i = 0; i < aircrafts.Length; i++)
            {
                for (int j = i; j < aircrafts.Length; j++)
                {
                    if (aircrafts[j].Price < aircrafts[i].Price)
                    {
                        var c = aircrafts[j];
                        aircrafts[j] = aircrafts[i];
                        aircrafts[i] = c;
                    }
                }
            }

            aircrafts.Display();
        }

        public static void ShellSort()
        {
            var aircrafts = GetAircraftsFromFile("Aircrafts.json");

            for (int gap = aircrafts.Length / 2; gap > 0; gap--)
            {
                for (int i = 0; i < aircrafts.Length - gap; i++)
                {
                    var current = aircrafts[i];
                    var other = aircrafts[i + gap];

                    if (current.Price > other.Price)
                    {
                        aircrafts[i + gap] = current;
                        aircrafts[i] = other;
                    }
                }
            }

            aircrafts.Display();
        }

        public static void HeapSort()
        {
            //var aircrafts = GetAircraftsFromFile("Aircrafts.json").Take(10).ToArray();
            int[] aircrafts = {74, 19, 24, 5, 8, 79, 42, 15, 20, 53, 11};

            aircrafts.DisplayInline();

            FixHeap(aircrafts, aircrafts.Length);
            aircrafts.DisplayInline();

            for (int i = aircrafts.Length - 1; i > 0; i--)
            {
                var c = aircrafts[0];
                aircrafts[0] = aircrafts[i];
                aircrafts[i] = c;

                //FixHeap(aircrafts, i);
            }

            //aircrafts.Display();
        }

        public static void FixHeap(int[] aircrafts, int lastHeapFixingIndex)
        {
            //Прогнаться по левой половине. Сравнить с элементами 2i+1 и 2i+2. Расположить так, чтобы они были меньше корневого.

            int middleIndex = lastHeapFixingIndex / 2;
            for (int i = middleIndex - 1; i >= 0; i--)
            {
                int firstIndex = 2 * i + 1;
                int secondIndex = 2 * i + 2;

                if (firstIndex < aircrafts.Length && aircrafts[i] < aircrafts[firstIndex])
                {
                    var c = aircrafts[i];
                    aircrafts[i] = aircrafts[firstIndex];
                    aircrafts[firstIndex] = c;
                }

                if (secondIndex < aircrafts.Length && aircrafts[i] < aircrafts[secondIndex])
                {
                    var c = aircrafts[i];
                    aircrafts[i] = aircrafts[secondIndex];
                    aircrafts[secondIndex] = c;
                }
            }
        }

        public static void MergeSort()
        {
            var aircrafts = GetAircraftsFromFile("Aircrafts.json");

            int g = 1;
            while (g < aircrafts.Length)
            {
                g *= 2;

                if (g > aircrafts.Length)
                {
                    g = aircrafts.Length;
                }

                for (int i = 0; i <= aircrafts.Length - g; i += g)
                {
                    int difference = g / 2;

                    var sorted = new List<Aircraft>();
                    for (int j = i; j < i + difference; j++)
                    {
                        var first = aircrafts[j];
                        var second = aircrafts[j + difference];

                        sorted.InsertBeforeHighest(first);
                        sorted.InsertBeforeHighest(second);
                    }

                    for (int j = 0; j < sorted.Count; j++)
                    {
                        aircrafts[i + j] = sorted[j];
                    }
                }
            }

            aircrafts.Display();
        }
    }
}