// http://programmingpraxis.com/2015/06/19/nines-and-zeros/
//
// Given an integer n, find the smallest number consisting only of the digits
// zero and nine that is divisible by n. For instance, given n = 23,
// the smallest number consisting only of the digits zero and nine that
// is divisible by 23 is 990909.

using System;

class Program 
{
    static long Smallest(int n, int divisor)
    {
        long a = 1;
        long number9 = 9;
        while (a < long.MaxValue && (number9 % divisor != 0))
        {
            number9 = BinaryTo9(a);
            a++;
        }

        return number9;
    }

    static long BinaryTo9(long number)
    {
        long result = 0;
        for (int i = 63; i >= 0; i--)
        {
            result = result * 10 + ((number >> i) & 1) * 9;
        }

        return result;
    }

    static void Main()
    {
        int n = 23;
        Console.WriteLine(Smallest(n, 23));
    }
}
