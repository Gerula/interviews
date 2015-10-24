// You have a sorted array containing the age of every person on earth.
// Find out how many people have a certain age.
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static Random rand = new Random();
    static void Times(this int n, Action a)
    {
        while (--n >= 0)
        {
            a();
        }
    }

    static int[] GenerateAges()
    {
        return Enumerable.
                Range(1, 100).
                SelectMany(x => Enumerable.Repeat(x, rand.Next(1, 100))).
                ToArray();
    }

    static Dictionary<int, int> Occurences(this int[] a)
    {
        return a.Aggregate(new Dictionary<int, int>(),
                           (acc, x) => {
                                if (!acc.ContainsKey(x))
                                {
                                    acc[x] = 0;
                                }

                                acc[x]++;
                                return acc;
                           });
    }

    static int HowMany(this int age, int[] everyone)
    {
        return everyone.GetPosition(age, false) - 
               everyone.GetPosition(age, true);
    }

    static int GetPosition(this int[] a, int target, bool left)
    {
        int low = 0;
        int high = a.Length;

        while (low < high)
        {
            int mid = low + (high - low) / 2;
            if (a[mid] == target)
            {
                if (left)
                {
                    high = mid;
                }
                else
                {
                    low = mid + 1;
                }
            }
            else if (a[mid] < target)
            {
                high = mid;
            }
            else
            {
                low = mid + 1;
            }
        }

        Console.WriteLine("{0} - {1}", target, low);
        return low;
    }

    static void Main()
    {
        var input = GenerateAges();
        foreach (var occurence in input.Occurences())
        {
            var age = occurence.Key;
            var howMany = age.HowMany(input);
            if (howMany != occurence.Value)
            {
                throw new Exception(String.Format(
                            "You're not good enough! Expected {0} for age {1} and got {2}",
                            occurence.Value,
                            occurence.Key,
                            howMany));
            }
        }

        Console.WriteLine("All appears to be well");
    }
}
