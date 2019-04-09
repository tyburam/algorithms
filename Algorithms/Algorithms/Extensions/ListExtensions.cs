using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.Extensions
{
    public static class ListExtensions
    {
        public static void WriteLine<T>(this IEnumerable<T> input)
        {
            foreach (var e in input)
            {
                Console.Write("{0} ", e);
            }
            Console.WriteLine();
        }
    }
}