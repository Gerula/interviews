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
    static IEnumerable<String> Search(this IEnumerable<String> words, String pattern) {
        return words.Where(x => x.Matches(pattern));
    }

    static bool Matches(this String word, String pattern) {
        var p = 0;
        var w = 0;
        while (p < pattern.Length && w < word.Length && 
                (char.IsUpper(pattern[p]) && pattern[p] != word[w] ||
                 pattern[p] == word[w]))
        {
            p += pattern[p] == word[w] ? 1 : 0;
            w += 1;
        }

        return p == pattern.Length;
    }

    static void Main() {
        var array = new [] { "HelloMars", "HelloWorld", "HelloWorldMars", "HiHo" };
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

