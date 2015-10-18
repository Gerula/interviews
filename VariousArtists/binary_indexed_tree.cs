using System;
using System.Collections.Generic;
using System.Linq;

static class Program 
{
    static IEnumerable<String> Decompose(this int n)
    {
        int pow = 0;
        while (n != 0)
        {
            if ((n & 1) == 1)
            {
                yield return String.Format("2^{0}", pow);
            }

            pow++;
            n >>= 1;
        }
    }

    static void Main()
    {
        for (int i = 2; i < 30; i++)
        {
            Console.WriteLine(
                    "{0} = {1}",
                    i,
                    String.Join(" + ", i.Decompose()));
        }
    }
}
