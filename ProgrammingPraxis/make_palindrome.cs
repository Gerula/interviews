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
                                        Select(x => (char)random.Next(65, 70)).
                                            ToArray());
    }

    static bool IsPalindrome(this String s)
    {
        if (String.IsNullOrEmpty(s))
        {
            return false;
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

    static String GeneratePalindromeInPlace(this String s)
    {
        var ordered = s.OrderBy(x => x).
                        GroupBy(y => y).
                        OrderBy(b => b.Count() % 2).
                        Reverse().
                        Select(b => Enumerable.Repeat(b.Key, b.Count())).
                        SelectMany(i => i);
        String result = new String(ordered.Where((x, i) => i % 2 == 1).ToArray()) + 
                        new String(ordered.Where((x, i) => i % 2 == 0).Reverse().ToArray());

        if (result.IsPalindrome()) 
        {
            return result;
        }

        return null;
    }

    static String GeneratePalindromeIdiot(this String s)
    {
        StringBuilder stringBuilder = new StringBuilder();
        
        List<char> odd = new List<char>();
        foreach (var c in s)
        {
            if (odd.Contains(c))
            {
                stringBuilder.Append(c);
                odd.Remove(c);
            } 
            else
            {
                odd.Add(c);
            }
        }

        if (odd.Count > 1 || stringBuilder.Length != s.Length / 2)
        {
            return null;
        }

        return stringBuilder.ToString() +
               String.Join(String.Empty, odd) +
               new String(stringBuilder.ToString().Reverse().ToArray());
    }

    static void SwapChars(ref char a, ref char b)
    {
        char c = a; a = b; b = c;
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
            String p = s.GeneratePalindromeInPlace();
            String q = s.GeneratePalindromeIdiot();
            Console.WriteLine("{0} {1} \n palindrome {2} {3} \n palindrome_2 {4} {5} \n palindrome_3 {6} {7} \n", 
                              s, 
                              s.IsPalindrome(),
                              t,
                              t.IsPalindrome(),
                              p,
                              p.IsPalindrome(),
                              q,
                              q.IsPalindrome());
        }
    }
}
