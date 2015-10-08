// http://careercup.com/question?id=5644130656976896
//
// Given n, return 1 ^ 2 ^ .. ^ n
//

using System;
using System.Linq;

static class Program
{
    static int Xor(this int n)
    {
        int result = 0;
        for (int i = 1; i <= n; i++)
        {
            result ^= i;
        }

        return result;
    }

    static int NinjaXor(this int n)
    {
        // 1 = 0 0 0 0 0 0 0 1
        // 2 = 0 0 0 0 0 0 1 0 xor = 3
        // 3 = 0 0 0 0 0 0 1 1 xor = 0
        // 4 = 0 0 0 0 0 1 0 0 xor = 4
        // 5 = 0 0 0 0 0 1 0 1 xor = 1
        // 6 = 0 0 0 0 0 1 1 0 xor = 7
        // 7 = 0 0 0 0 0 1 1 1 xor = 0
        // 8 = 0 0 0 0 1 0 0 0 xor = 8

        switch (n % 4)
        {
            case 0: return n;
            case 1: return 1;
            case 2: return n + 1;
            case 3: return 0;
            default: return int.Parse("hahahhahaa");
        }
    }

    static void Main() 
    {
        for (int i = 1; i < 400; i++)
        {
            int actualXor = Enumerable.
                            Range(1, i).
                            Aggregate(0, (acc, x) => acc ^ x);
             
            if (i.Xor() != actualXor ||
                i.NinjaXor() != actualXor )
            {
                throw new Exception("You are an idiot");
            }
        }

        Console.WriteLine("All appears to be well!");
    }
}
