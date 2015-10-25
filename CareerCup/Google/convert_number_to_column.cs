// http://careercup.com/question?id=5690323227377664
//
// Write a function which takes an integer and convert to string as:
// 1 - A         0001
// 2 - B         0010
// 3 - AA        0011
// 4 - AB        0100
// 5 - BA        0101
// 6 - BB        0110
// 7 - AAA       0111
// 8 - AAB       1000
// 9 - ABA       1001
// 10 - ABB
// 11 - BAA
// 12 - BAB
// 13 - BBA
// 14 - BBB
// 15 - AAAA

using System;

static class Program
{
    static String ToS(this int i)
    {
        String result = String.Empty;
        while (i > 0)
        {
            if ((i & 1) == 0)
            {
                result += "B";
                i -= 1;
            }
            else
            {
                result += "A";
            }

            i >>= 1;
        }
        
        return result;
    }

    static void Main()
    {
        for (int i = 1; i < 16; i++)
        {
            Console.WriteLine("{0} - {1}", i, i.ToS());
        }
    }
}
