// https://leetcode.com/problems/bulls-and-cows/
//
// You are playing the following Bulls and Cows game with your friend:
// You write a 4-digit secret number and ask your friend to guess it,
// each time your friend guesses a number, you give a hint,
// the hint tells your friend how many digits are in the correct positions (called "bulls")
// and how many digits are in the wrong positions (called "cows"),
// your friend will use those hints to find out the secret number.
//  
// Remarkably, a variation of this problem was posted on DailyProgrammer on Reddit.
//
// 
// Submission Details
// 152 / 152 test cases passed.
//  Status: Accepted
//  Runtime: 144 ms
//      
//      Submitted: 0 minutes ago
//
//
// This was more tedious than I initially thought.. Need to pay more attention and not drink beer while doing these.

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    public static string GetHint(this string secret, string guess) {
        var bullshits = secret.
                        Zip(guess, (x, y) => x == y).
                        Count(z => z);
        var histogram = secret.Aggregate(
                        new Dictionary<char, int>(),
                        (agg, x) => {
                            if (!agg.ContainsKey(x))
                            {
                                agg[x] = 0;
                            }

                            agg[x]++;
                            return agg;
                        });

        var cowshits = guess.Aggregate(
                       0,
                       (agg, x) => {
                            if (histogram.ContainsKey(x) && histogram[x] > 0)
                            {
                                agg++;
                                histogram[x]--;
                            }

                            return agg;
                       }) - bullshits;
                        

        return String.Format("{0}A{1}B", bullshits, cowshits);
    }

    public static string GetHint2(this String secret, String guess)
    {
        var occurences = Enumerable.Repeat(0, 10).ToArray();
        var bullshits = 0;
        var cowshits = 0;
        for (int i = 0; i < secret.Length; i++)
        {
            var first = int.Parse(secret[i].ToString());
            var second = int.Parse(guess[i].ToString());
            if (first == second)
            {
                bullshits++;
            }
            else
            {
                cowshits += (occurences[first]++ < 0) ? 1 : 0;
                cowshits += (occurences[second]-- > 0) ? 1 : 0;
            }
        }

        return String.Format("{0}A{1}B", bullshits, cowshits);
    }

    static void Main()
    {
        Console.WriteLine("1807".GetHint("7810"));
        Console.WriteLine("1807".GetHint2("7810"));
        Console.WriteLine();
        Console.WriteLine("1".GetHint("0"));
        Console.WriteLine("1".GetHint2("0"));
        Console.WriteLine();
        Console.WriteLine("11".GetHint("10"));
        Console.WriteLine("11".GetHint2("10"));
        Console.WriteLine();
        Console.WriteLine("12".GetHint("23"));
        Console.WriteLine("12".GetHint2("23"));
        Console.WriteLine();
        Console.WriteLine("1234".GetHint("0111"));
        Console.WriteLine("1234".GetHint2("0111"));
    }
}
