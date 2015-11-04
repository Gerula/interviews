// https://www.reddit.com/r/dailyprogrammer/comments/3r7wxz/20151102_challenge_239_easy_a_game_of_threes/
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static int[] remainders = new [] { 0, -1, 1 };

    static IEnumerable<Tuple<int, int>> Game(this int n)
    {
        while (n != 0)
        {
            yield return Tuple.Create(n, n % 3);
            n += remainders[n % 3];
            n /= 3;
        }
    }

    static void Main()
    {
        Console.WriteLine(String.Join(
                    Environment.NewLine,
                    Enumerable.
                    Range(10, 100).
                    Select(x => String.Format(
                                    "{0} = {1}",
                                    x,
                                    String.Join(",", x.Game())))));
    }
}
