// https://www.reddit.com/r/dailyprogrammer/comments/3opin7/20151014_challenge_236_intermediate_fibonacciish/
//
// The Fibonacci Sequence is a famous integer series in the field of mathematics.
// The sequence is recursively defined for n > 1 by the formula f(n) = f(n-1) + f(n-2).
// In plain english, each term in the sequence is found by adding the previous two terms together.
// Given the starting values of f(0) = 0 and f(1) = 1 the first ten terms of the sequence are:
//
//     0 1 1 2 3 5 8 13 21 34
//
// We will notice however that some numbers are left out of the sequence and don't get any of the fame, 9 is an example.
// However, if we were to start the sequence with a different value for f(1) we will generate a new sequence of numbers. Here is the series for f(1) = 3:
//
//     0 3 3 6 9 15 24 39 102 165
//
// We now have a sequence that contains the number 9. What joy!
// Today you will write a program that will find the lowest positive integer for f(1) that will generate a Fibonacci-ish sequence containing the desired integer (let's call it x).
//

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static IEnumerable<long> Fibonacci(long start, long limit)
    {
        long a = 0;
        long b = start;
        yield return a;
        while (b < limit)
        {
            yield return b;
            long c = a + b;
            a = b;
            b = c;
        }
    }

    static long Factor(Dictionary<long, long> cache, long n)
    {
        return n / cache.Keys.Skip(3).Last(x => n % x == 0);
    }

    static void Main()
    {
        var cache = Fibonacci(1, int.MaxValue).
                        Select((val, index) => new { index, val }).
                        Aggregate(new Dictionary<long, long>(),
                                  (acc, x) => {
                                    acc[x.val] = x.index;
                                    return acc;
                                  });
        new [] { 21, 84, 578, 123456789 }.
            ToList().
            ForEach(x => {
                long factor = Factor(cache, x);
                factor = factor == x ? 1 : factor;
                Console.WriteLine(
                    "{0} - {1} - {2}",
                    x,
                    factor, 
                    String.Join(", ", Fibonacci(factor, int.MaxValue)));
            });
    }
}
