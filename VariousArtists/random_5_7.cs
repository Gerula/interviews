//  You have a function rand7() that generates a random integer from 1 to 7.
//  Use it to write a function rand5() that generates a random integer from 1 to 5.
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static Random rand = new Random();

    static int Rand7()
    {
        return rand.Next(1, 7 + 1);
    }
    
    static int Rand5()
    {
        int result;
        while ((result = Rand7()) > 5) { }
        return result;
    }

    static void Main()
    {
        var first = Enumerable.
                    Range(1, 10000000).
                    Select(x => Rand5()).
                    Aggregate(new Dictionary<int, int>(),
                              (acc, y) => {
                                if (!acc.ContainsKey(y))
                                {
                                    acc[y] = 0;
                                }

                                acc[y]++;
                                return acc;
                              });
        Console.WriteLine(
                String.Join(Environment.NewLine,
                    first.Select(z => String.Format("{0} - {1}", 
                                              z.Key, 
                                              z.Value))));

    }
}
