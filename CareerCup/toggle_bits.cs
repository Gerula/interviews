// http://careercup.com/question?id=5198851868721152
//
// Write a program to toggle bits 
//
// Input: n, start bit, end bit.
//

using System;

static class Program
{
    static int Toggle(this int n, int start, int numBits)
    {
        int mask = 1 << start;
        for (int i = 0; i < numBits; i++)
        {
            n ^= mask;
            mask <<= 1;
        }

        return n;
    }

    static void Main()
    {
        Random rand = new Random();
        for (int i = 0; i < 10; i++)
        {
            int n = rand.Next(int.MaxValue / 2, int.MaxValue);
            Console.WriteLine("{0}, {1}",
                               Convert.ToString(n, 2),
                               Convert.ToString(n.Toggle(0, 10), 2));
        }
    }
}
