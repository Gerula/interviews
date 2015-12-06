//  http://www.geeksforgeeks.org/print-all-good-numbers-in-given-range/
//
//  Given a digit ‘d’ and a range [L, R] where L < R,
//  print all good numbers in given range that don't contain digit 'd'.
//  A number is good if its every digit is larger than the sum of digits
//  which are on the right side of that digit. For example 9620 is good number because 2 > 0, 6 > 2+0 and 9 > 6+2+0.

using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    static IEnumerable<int> GoodNums(int d, int low, int high)
    {
        return Enumerable
               .Range(low, high - low + 1)
               .Where(x => {
                       var sum = -1;
                       while (x != 0 && x % 10 != d && x % 10 > sum)
                       {
                            sum = sum == -1 ? x % 10 : sum + x % 10;
                            x /= 10;
                       }

                       return x == 0;
               });
    }

    static void Main()
    {
        Console.WriteLine(String.Join(", ", GoodNums(3, 410, 520)));
        Console.WriteLine(String.Join(", ", GoodNums(1, 410, 520)));
    }
}
