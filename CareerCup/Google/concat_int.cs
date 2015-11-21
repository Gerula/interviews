// http://careercup.com/question?id=5723915160649728
//
// Given a list of integers, find the highest value obtainable by concatenating
// them.
//
// Example:
// 9, 918, 917 -> 9918917
// 1, 112, 113 -> 1131121
//

using System;
using System.Linq;

static class Program
{
    static String MaxNum(this int[] numbers)
    {
        var numbersString = numbers.Select(x => x.ToString()).ToArray();
        Array.Sort(
                numbersString,
                (a, b) =>
                {
                    var first = int.Parse(a + b);
                    var second = int.Parse(b + a);
                    if (first < second)
                    {
                        return 1;
                    }

                    if (first > second)
                    {
                        return -1;
                    }

                    return 0;
                });

        return String.Join(String.Empty, numbersString);
    }

    static void Main()
    {
        Console.WriteLine(new [] { 9, 918, 917 }.MaxNum());
        Console.WriteLine(new [] { 1, 112, 113 }.MaxNum());
    }
}
