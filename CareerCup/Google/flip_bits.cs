// http://careercup.com/question?id=5668664122540032
//
// Give n lightbulbs, write two methods:
// - isOn(i)
// - toggle(i, j) - flips all between i and j
//
// toggle needs to be faster than O(n)
//

using System;
using System.Collections;
using System.Linq;

static class Program
{
    static Random rand = new Random();

    static String StringTo(this BitArray b)
    {
        return String.Join(
                String.Empty,
                b.Cast<bool>().
                    Select(x => x? "X" : " "));
    }

    static BitArray GenerateBulbs()
    {
        var result = new BitArray(rand.Next(20, 30), false);
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = rand.Next(1, 100) % 3 == 0;
        }

        return result;
    }

    static void Main()
    {
        var bulbs = GenerateBulbs();
        Console.WriteLine(bulbs.StringTo());
    }
}
