using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                numbers.Add(i);
            }

            var numbersLinq = numbers.Where(number => number %2==0);

            foreach (var number in numbersLinq)
                Console.WriteLine(number);
        }
    }

    class TestList
    {

    }
}
