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

    static void Main()
    {
        var dictionary = new HashSet<String> {"apple", "tablet", "able", "t", "app", "let"};
        Console.WriteLine(String.Join(Environment.NewLine, "appletablet".WordBreak(dictionary)));
    }
}
