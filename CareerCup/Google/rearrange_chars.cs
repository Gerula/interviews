// http://careercup.com/question?id=5693863291256832
//
// Rearrange chars in a String so that no adjacent chars repeat
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

static class Program
{
    static Random random = new Random();

    static String Rearrange(this String s)
    {
        return null;
    }

    static String GenerateString()
    {
        return String.Join(String.Empty, Enumerable.Repeat(0, random.Next(20, 30)).Select(x => (char)random.Next('a', 'z')));
    }

    static void Main()
    {
        for (int i = 0; i < 10; i++)
        {
            String s = GenerateString();
            String p = s.Rearrange();
            Console.WriteLine("{0} = {1}", s, p == null? "Not possible" : p);
        }
    }
}
