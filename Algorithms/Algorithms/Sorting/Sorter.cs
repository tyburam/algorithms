using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Algorithms.Sorting
{
    public class Sorter
    {
        public static IList<T> SelectionSort<T>(IList<T> input)
        {
            var data = new List<T>(input);
            var sorted = new List<T>();

            while (data.Any())
            {
                var min = data.Min();
                sorted.Add(min);
                data.Remove(min);
            }

            return sorted;
        }

        public static IList<T> BubbleSort<T>(IList<T> input)
        {
            var sorted = new List<T>(input);

            for (var i = 0; i < sorted.Count; i++)
            {
                for (var j = 0; j < sorted.Count - 1; j++)
                {
                    if (!IsLessThan(sorted[i], sorted[j])) continue;
                    var tmp = sorted[i];
                    sorted[i] = sorted[j];
                    sorted[j] = tmp;
                }
            }

            return sorted;
        }

        public static IList<T> InsertionSort<T>(IList<T> input)
        {
            var sorted = new List<T>(input);

            for (var i = 1; i < sorted.Count; i++)
            {
                if (!IsLessThan(sorted[i], sorted[i - 1])) continue;

                for (var j = 0; j < i; j++)
                {
                    if (!IsLessThan(sorted[i], sorted[j])) continue;
                    var tmp = sorted[i];
                    sorted[i] = sorted[j];
                    sorted[j] = tmp;
                }
            }

            return sorted;
        }

        public static IList<T> MergeSort<T>(IList<T> input)
        {
            var sorted = new List<T>(input);
            MergingSort(sorted, 0, sorted.Count - 1);
            return sorted;
        }

        public static IList<T> QuickSort<T>(IList<T> input)
        {
            var sorted = new List<T>(input);
            QuickSorting(sorted, 0, sorted.Count - 1);
            return sorted;
        }

        public static IList<int> CountingSort(IList<int> input)
        {
            var counter = new List<int>();

            foreach (var t in input)
            {
                while (counter.Count < t + 1)
                {
                    counter.Add(0);
                }

                ++counter[t];
            }

            var output = new List<int>();
            for (var i = 0; i < counter.Count; i++)
            {
                for (var j = 0; j < counter[i]; j++)
                {
                    output.Add(i);
                }
            }

            return output;
        }

        public static IList<T> HeapSort<T>(IList<T> input)
        {
            var heap = new List<T>(input);

            for (var i = input.Count / 2 - 1; i >= 0; i--)
            {
                Heapify(input, i);
            }

            for (var i = input.Count - 1; i >= 0; i--) 
            { 
                var tmp = input[0];
                input[0] = input[i];
                input[0] = tmp;
  
                Heapify(input, 0); 
            }

            return heap;
        }

        private static bool IsLessThan<T>(T x, T y)
        {
            return ((IComparable) (x)).CompareTo(y) <= 0;
        }

        private static bool IsLargerThan<T>(T x, T y)
        {
            return ((IComparable) (x)).CompareTo(y) > 0;
        }

        private static void MergingSort<T>(IList<T> input, int left, int right)
        {
            if (left > right)
            {
                return;
            }

            var middle = (left + right) / 2;
            if (middle > left)
            {
                MergingSort<T>(input, left, middle);
            }

            if (right > middle + 1)
            {
                MergingSort<T>(input, middle + 1, right);
            }

            Merge<T>(input, left, middle, right);
        }

        private static void Merge<T>(IList<T> input, int left, int middle, int right)
        {
            int i = 0, j = 0, k = left;
            int n1 = middle - left + 1, n2 = right - middle;
            IList<T> l = new List<T>(), r = new List<T>();

            for (i = 0; i < n1; i++)
            {
                l.Add(input[left + i]);
            }

            for (i = 0; i < n2; i++)
            {
                r.Add(input[middle + i + 1]);
            }

            i = 0;
            while (i < n1 && j < n2)
            {
                if (IsLessThan(l[i], r[j]))
                {
                    input[k] = l[i];
                    i++;
                }
                else
                {
                    input[k] = r[j];
                    j++;
                }

                k++;
            }

            while (i < n1)
            {
                input[k] = l[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                input[k] = r[j];
                j++;
                k++;
            }
        }

        private static void QuickSorting<T>(List<T> sorted, int left, int right)
        {
            if (left > right)
            {
                return;
            }

            var middle = Partition<T>(sorted, left, right);
            if (middle > left)
            {
                QuickSorting<T>(sorted, left, middle - 1);
            }

            if (right > middle + 1)
            {
                QuickSorting<T>(sorted, middle + 1, right);
            }
        }

        private static int Partition<T>(List<T> sorted, int left, int right)
        {
            var pivot = right;
            var index = left;
            for (var i = left; i <= right - 1; i++)
            {
                if (!IsLessThan(sorted[i], sorted[pivot])) continue;
                var tmp = sorted[i];
                sorted[i] = sorted[index];
                sorted[index] = tmp;
                ++index;
            }

            var tmp2 = sorted[index];
            sorted[index] = sorted[pivot];
            sorted[pivot] = tmp2;

            return index;
        }

        public static void Heapify<T>(IList<T> input, int rootIndex)
        {
            int largest = rootIndex, left = 2 * rootIndex + 1, right = 2 * rootIndex + 2;

            if (left < input.Count && IsLargerThan(input[left], input[largest]))
            {
                largest = left;
            }

            if (right < input.Count && IsLargerThan(input[right], input[largest]))
            {
                largest = right;
            }

            if (largest == rootIndex) return;
            var tmp = input[largest];
            input[largest] = input[rootIndex];
            input[rootIndex] = tmp;

            Heapify(input, largest);
        }
    }
}