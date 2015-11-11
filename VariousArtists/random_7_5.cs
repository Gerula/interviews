// You have a function rand5() that generates a random integer from 1 to 5.
// Use it to write a function rand7() that generates a random integer from 1 to 7. 
//

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static Random rand = new Random();

    static int Rand5()
    {
        return rand.Next(1, 6);
    }

    static int Rand7()
    {
        return new int[,] {
            {1, 2, 3, 4, 5},
            {6, 7, 1, 2, 3},
            {4, 5, 6, 7, 1},
            {2, 3, 4, 5, 6},
            {7, 1, 2, 3, 4}
        }[Rand5() - 1, Rand5() - 1];
    }

    static int Rand72()
    {
        return 1 * (Rand5() <= 2 ? 0 : 1) +
               2 * (Rand5() == 2) +
               4 * (Rand5() >= 3 ? 1 : 0);
    }

    static void Main()
    {
        Enumerable.
            Repeat(1, 7000000).
            Select(x => Rand7()).
            Aggregate(
                    new Dictionary<int, int>(),
                    (acc, y) => {
                        if (!acc.ContainsKey(y))
                        {
                            acc[y] = 0;
                        }

                        acc[y]++;
                        return acc;
                    }).
            OrderBy(z => z.Key).
            ToList().
            ForEach(w => {
                        Console.WriteLine("{0} = {1}", w.Key, w.Value);
                    });

        Console.WriteLine();
        Enumerable.
            Repeat(1, 7000000).
            Select(x => Rand72()).
            Aggregate(
                    new Dictionary<int, int>(),
                    (acc, y) => {
                        if (!acc.ContainsKey(y))
                        {
                            acc[y] = 0;
                        }

                        acc[y]++;
                        return acc;
                    }).
            OrderBy(z => z.Key).
            ToList().
            ForEach(w => {
                        Console.WriteLine("{0} = {1}", w.Key, w.Value);
                    });
    }
}
