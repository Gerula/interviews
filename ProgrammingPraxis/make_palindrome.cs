// http://programmingpraxis.com/2015/09/29/making-a-palindrome/
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

static class Program
{
    static Random random = new Random();
 
    static String GenerateString()
    {
        return new String(Enumerable.Repeat(0, random.Next(10, 30)).
                                        Select(x => (char)random.Next(65, 75)).
                                            ToArray());
    }

    static bool IsPalindrome(this String s)
    {
        if (String.IsNullOrEmpty(s))
        {
            return true;
        }

        return !s.Select((u, i) => new {
                                            character = u, 
                                            index = i 
                                       }).
                   Any(x => x.character != s[s.Length - x.index - 1]);
    }

    static String GeneratePalindrome(this String s)
    {
        var histogram = s.Aggregate(new Dictionary<char, int>(), 
                                    (agg, c) => {
                                        if (!agg.ContainsKey(c))
                                        {
                                            agg[c] = 0;
                                        }

                                        agg[c] += 1;
                                        return agg;
                                    });
        
        if (s.Length % 2 != histogram.Values.Count(x => x % 2 == 1))
        {
            return null;
        }

        return histogram.
               Keys.
               OrderBy(x => histogram[x] % 2).
               Reverse().
               Aggregate(new StringBuilder(),
                       (agg, c) => {
                            int count = histogram[c];
                            if (count % 2 == 1)
                            {
                                agg.Append(GetStringRepeated(c, count));
                            }
                            else
                            {
                                agg.Insert(0, GetStringRepeated(c, count / 2)); 
                                agg.Append(GetStringRepeated(c, count / 2)); 
                            }

                            return agg;
                       }).ToString();
    }

    static String GeneratePalindromeConstantSpace(this String s)
    {
        return s;
    }

    static String GetStringRepeated(char c, int times)
    {
        return new String(Enumerable.Repeat(c, times).ToArray());
    }

    static void Main()
    {
        for (int i = 0; i < random.Next(10, 50); i++) 
        {
            String s = GenerateString();
            String t = s.GeneratePalindrome();
            String p = s.GeneratePalindromeConstantSpace();
            Console.WriteLine("{0} {1} palindrome {2} {3} palindrome_2 {4} {5}", 
                              s, 
                              s.IsPalindrome(),
                              t,
                              t.IsPalindrome(),
                              p,
                              p.IsPalindrome());
        }
    }
}
