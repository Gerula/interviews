// http://programmingpraxis.com/2015/09/29/making-a-palindrome/
//

using System;
using System.Linq;

static class Program
{
    static Random random = new Random();
 
    static String GenerateString()
    {
        return new String(Enumerable.Repeat(0, random.Next(10, 30)).
                                        Select(x => (char)random.Next(65, 90)).
                                            ToArray());
    }

    static bool IsPalindrome(this String s)
    {
        for (int i = 0; i < s.Length / 2; i++)
        {
            if (s[i] != s[s.Length - i - 1]) 
            {
                return false;
            }
        }

        return true;
    }

    static void Main()
    {
        for (int i = 0; i < 10; i++) 
        {
            String s = GenerateString();
            Console.WriteLine("{0} {1}", s, s.IsPalindrome());
        }
    }
}
