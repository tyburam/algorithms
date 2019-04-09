using System;
using System.Collections.Generic;

namespace Algorithms.Generators
{
    public class ListGenerator
    {
        public static IList<int> Generate(long count, int seed = 2019)
        {
            var rnd = new Random(seed);
            var output = new List<int>();

            for (var i = 0; i < count; i++)
            {
                output.Add(rnd.Next(1024));
            }

            return output;
        }
    }
}