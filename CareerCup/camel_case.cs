//  https://careercup.com/question?id=5660887265312768
//  List of string that represent class names in CamelCaseNotation.
//  
//  Write a function that given a List and a pattern returns the matching elements.
//  ['HelloMars', 'HelloWorld', 'HelloWorldMars', 'HiHo']
//
//  H -> [HelloMars, HelloWorld, HelloWorldMars, HiHo]
//  HW -> [HelloWorld, HelloWorldMars]
//  Ho -> []
//  HeWorM -> [HelloWorldMars]

using System;
using System.Collections.Generic;
using System.Linq;

static class Solution {
    static Dictionary<String, int[]> jump;

    static IEnumerable<String> Search(this IEnumerable<String> words, String pattern) {
        return words.Where(x => x.Matches(pattern));
    }

    static bool Matches(this String word, String pattern) {
        var p = 0;
        var w = 0;
        while (p < pattern.Length && w < word.Length)
        {
            if (pattern[p] == word[w]) {
                p++;
                w++;
            } else if (Char.IsUpper(pattern[p]) && !Char.IsUpper(word[w])) {
                w = jump[word][w];
            } else {
                break;
            }
        }

        return p == pattern.Length;
    }

    static int[] Jump(this String s)
    {
        var last = s.Length;
        var result = new int[s.Length];
        for (var i = s.Length - 1; i >= 0; i--) {
            if (Char.IsUpper(s[i])) {
                last = i;
            } 

            result[i] = last;
        }

        return result;
    }

    static void Main() {
        var array = new [] { "HelloMars", "HelloWorld", "HelloWorldMars", "HiHo" };
        jump = array.Select(x => new { key = x, val = Jump(x) }).ToDictionary(x => x.key, x => x.val );
        Console.WriteLine(
                String.Join(
                    Environment.NewLine,
                    new [] { "H", "HW", "Ho", "HeWorM" }
                    .Select(x => String.Format(
                                "{0} - [{1}] - [{2}]",
                                x,
                                String.Join(", ", array),
                                String.Join(", ", array.Search(x))))));
    }
}

