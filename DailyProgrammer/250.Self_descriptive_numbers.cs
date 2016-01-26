//  https://www.reddit.com/r/dailyprogrammer/comments/41tdzy/20160120_challenge_250_intermediate/
//
//  A descriptive number tells us how many digits we have depending on its index.
//
//  For a number with n digits in it, the most significant digit stands for the '0's and the least significant stands for (n - 1) digit.
//
//  As example the descriptive number of 101 is 120 meaning:
//
//      It contains 1 at index 0, indicating that there is one '0' in 101;
//      It contains 2 at index 1, indicating that there are two '1' in 101;
//      It contains 0 at index 2, indicating that there are no '2's in 101;
//
//  Today we are looking for numbers that describe themself:
//
//  In mathematics, a self-descriptive number is an integer m that in a given base b is b digits long in which each digit d at position n (the most significant digit being at position 0 and the least significant at position b - 1) counts how many instances of digit n are in m.
//
//  Source
//
//  As example we are looking for a 5 digit number that describes itself. This would be 21200:
//
//  It contains 2 at index 0, indicating that there are two '0's in 21200;
//  It contains 1 at index 1, indicating that there is one '1' in 21200;
//  It contains 2 at index 2, indicating that there are two '2's in 21200;
//  It contains 0 at index 3, indicating that there are no '3's in 21200;
//  It contains 0 at index 4, indicating that there are no '4's in 21200;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

static class Program
{
    static IEnumerable<long> Oglaf(this int rank)
    {
        long low = (long) Math.Pow(10, rank - 1);
        long high = (long) Math.Pow(10, rank) - 1;
        
        for (var i = low; i < high; i++)
        {
            if (i.IsSelfDescriptive())
            {
                yield return i;
            }
        }
    }

    static bool IsSelfDescriptive(this long n)
    {
        var digits = n
                     .ToString()
                     .Select(x => int.Parse(x.ToString()))
                     .Aggregate(
                        new Dictionary<int, int>(),
                        (acc, x) => {
                            if (!acc.ContainsKey(x))
                            {
                                acc[x] = 0;
                            }

                            acc[x]++;
                            return acc;
                        });

        var s = n.ToString();
        var description = Enumerable
                          .Range(0, s.Length)
                          .Aggregate(
                             new Dictionary<int, int>(),
                             (acc, x) => {
                                if (s[x] == '0')
                                {
                                    return acc;
                                }

                                acc[x] = int.Parse(s[x].ToString());
                                return acc;
                             });

        return digits.OrderBy(x => x.Key).SequenceEqual(description.OrderBy(x => x.Key));
    }

    static void Main()
    {
        foreach (var x in new [] { 4, 5, 10, 15 })
        {
            Console.WriteLine(x);
            Console.WriteLine(String.Join(Environment.NewLine, x.Smart()));
            Console.WriteLine();
        }
    }
}
