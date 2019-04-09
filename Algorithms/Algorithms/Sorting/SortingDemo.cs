using System;
using Algorithms.Extensions;
using Algorithms.Generators;

namespace Algorithms.Sorting
{
    public class SortingDemo
    {
        public static void Run()
        {
            var data = ListGenerator.Generate(256);
            data.WriteLine();
            
            
            Console.WriteLine();
            Console.WriteLine("Selection sort");
            Console.WriteLine();
            var sorted1 = Sorter.SelectionSort(data);
            sorted1.WriteLine();
            
            Console.WriteLine();
            Console.WriteLine("Bubble sort");
            Console.WriteLine();
            var sorted2 = Sorter.BubbleSort(data);
            sorted2.WriteLine();
            
            Console.WriteLine();
            Console.WriteLine("Insertion sort");
            Console.WriteLine();
            var sorted3 = Sorter.InsertionSort(data);
            sorted3.WriteLine();
            
            Console.WriteLine();
            Console.WriteLine("Merge sort");
            Console.WriteLine();
            var sorted4 = Sorter.MergeSort(data);
            sorted4.WriteLine();
            
            Console.WriteLine();
            Console.WriteLine("Quick sort");
            Console.WriteLine();
            var sorted5 = Sorter.QuickSort(data);
            sorted5.WriteLine();
            
            Console.WriteLine();
            Console.WriteLine("Counting sort");
            Console.WriteLine();
            var sorted6 = Sorter.CountingSort(data);
            sorted5.WriteLine();
            
            Console.WriteLine();
            Console.WriteLine("Heap sort");
            Console.WriteLine();
            var sorted7 = Sorter.HeapSort(data);
            sorted5.WriteLine();
        }
    }
}