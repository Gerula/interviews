// Let's pursue Monday's Game of Threes further!
//
// To make it more fun (and make it a 1-player instead of a 0-player game),
// let's change the rules a bit: You can now add any of [-2, -1, 1, 2] to reach a multiple of 3.
// This gives you two options at each step, instead of the original single option.
//
// With this modified rule, find a Threes sequence to get to 1,
// with this extra condition: The sum of all the numbers that were added must equal 0.
// If there is no possible correct solution, print Impossible.
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program 
{
    static Dictionary<ulong, Dictionary<int, List<int>>> memory = new Dictionary<ulong, Dictionary<int, List<int>>>();

    static List<Tuple<ulong, int>> Threes(this ulong n)
    {
        var result = new List<int>();
        var partial = new List<int>();
        GetSum(n, 0, partial, result);
        return result.Select(x => {
                    var item = Tuple.Create(n, x);
                    n += (ulong)x;
                    n /= 3;
                    return item;
                }).ToList();
    }

    static void GetSum(ulong n,
                       int sum,
                       List<int> partial,
                       List<int> result)
    {
        var remainder = n % 3;
        if (result.Count > 0)
        {
            return;
        }

        if (n == 1)
        {
            if (sum == 0)
            {
                result.AddRange(new List<int>(partial));
                return;
            }

            return;
        }

        if (n < 2)
        {

            return;
        }

        if (memory.ContainsKey(n) 
        {
            if (memory[n].ContainsKey(-sum))
            {
                partial.AddRange(memory[n][-sum]);
                GetSum(1, 0, partial, result);
            }

            return;
        }

        switch (remainder) {
            case 0: {
                        partial.Add(0);
                        GetSum(n / 3, sum, partial, result); 
                        partial.RemoveAt(partial.Count - 1);
                        break;
                    }
            case 1: {
                        partial.Add(-1);
                        GetSum((n - 1) / 3, sum - 1, partial, result);
                        partial.RemoveAt(partial.Count - 1);
                        partial.Add(2);
                        GetSum((n + 2) / 3, sum + 2, partial, result);
                        partial.RemoveAt(partial.Count - 1);
                        break;
                    }
            case 2: {
                        partial.Add(-2);
                        GetSum((n - 2) / 3, sum - 2, partial, result);
                        partial.RemoveAt(partial.Count - 1);
                        partial.Add(1);
                        GetSum((n + 1) / 3, sum + 1, partial, result);
                        partial.RemoveAt(partial.Count - 1);
                        break;
                    }
        }
    }

    static void Main()
    {
        Console.WriteLine(String.Join(Environment.NewLine, 
                    ((ulong)929).Threes()));
        Console.WriteLine();
        Console.WriteLine(String.Join(Environment.NewLine, 
                    18446744073709551615.Threes()));
        Console.WriteLine();
        Console.WriteLine(String.Join(Environment.NewLine, 
                    18446744073709551614.Threes()));
        Console.WriteLine();
    }
}

