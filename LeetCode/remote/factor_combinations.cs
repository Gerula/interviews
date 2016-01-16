//  Numbers can be regarded as product of its factors. For example,
//
//      8 = 2 x 2 x 2;
//        = 2 x 4.
//
//  Write a function that takes an integer n and return all possible combinations of its factors.
//
//  Each combination’s factors must be sorted ascending, for example: The factors of 2 and 6 is [2, 6], not [6, 2].
//
//  You may assume that n is always positive.
//
//  Factors should be greater than 1 and less than n.

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    public static List<List<int>> GetFactors(this int n, int start = 2) 
    {
        var result = new List<List<int>> { new List<int> { n } };
        
        for (var i = start; i < Math.Sqrt(n); i++)
        {
            if (n % i == 0)
            {
                foreach (var x in (n / i).GetFactors(start))
                {
                    result.Add(new [] { i }.Concat(x).ToList());
                }
            }
        }

        return result;
    }

    static void Main()
    {
        foreach (var i in new [] { 1, 37, 12, 36, 35 })
        {
            Console.WriteLine(i);
            Console.WriteLine(String.Join(Environment.NewLine, i.GetFactors().Select(x => String.Join(", ", x))));
            Console.WriteLine();
        }
    }
}
