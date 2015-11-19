// http://careercup.com/question?id=5645065735110656
//
// Given a dictionary and a string, how many sentences can be formed
// such as all words are part of the dictionary
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program 
{
    static List<String> WordBreak(this String s, HashSet<String> dictionary)
    {
        var result = new List<String>();
        WBBackTracking(dictionary, s, 0, new List<String>(), result);
        return result;
    }

    static void WBBackTracking(
            HashSet<String> dictionary,
            String s,
            int position, 
            List<String> partial,
            List<String> result)
    {
        if (position == s.Length)
        {
            result.Add(String.Join(", ", partial));
            return;
        }

        for (var i = 1; i <= s.Length - position; i++)
        {
            var word = s.Substring(position, i);
            if (dictionary.Contains(word))
            {
                partial.Add(word);
                WBBackTracking(dictionary, s, position + i, partial, result);
                partial.RemoveAt(partial.Count - 1);
            }
        }
    }

    static int WB(this String s, HashSet<String> dictionary)
    {
        var dp = new int[s.Length + 1];
        for (var i = 0; i < s.Length - 1; i++)
        {
            if (dp[i] == 0 && i > 0)
            {
                continue;
            }

            for (var j = 1; j < s.Length - i; j++)
            {
                if (dictionary.Contains(s.Substring(i, j)))
                {
                    dp[i + j] += (i > 0 ? dp[i - 1] : 1) + 1;
                }
            }
        }

        return dp[s.Length - 1];
    }

    static void Main()
    {
        var dictionary = new HashSet<String> {"apple", "tablet", "able", "t", "app", "let"};
        Console.WriteLine(String.Join(Environment.NewLine, "appletablet".WordBreak(dictionary)));
        Console.WriteLine("appletablet".WB(dictionary));
    }
}
