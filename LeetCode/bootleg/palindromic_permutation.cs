//  http://lcoj.tk/problems/palindrome-permutation/
//
//   Given a string s, return all the palindromic permutations (without duplicates) of it.
//   Return an empty list if no palindromic permutation could be form.
//
//   For example:
//
//   Given s = "aabb", return ["abba", "baab"].
//
//   Given s = "abc", return []. 

using System;
using System.Collections.Generic;
using System.Linq;

static class Solution {
    public static IList<string> GeneratePalindromes(string s) {
        var occurences = s.Aggregate(
                            new Dictionary<char, int>(),
                            (acc, x) => {
                                if (!acc.ContainsKey(x))
                                {
                                    acc[x] = 0;
                                }

                                acc[x]++;
                                return acc;
                            });
        
        var odds = occurences.Where(x => x.Value % 2 == 1);
        if (odds.Count() > 2)
        {
            return new List<string>();
        }

        var odd = String.Empty;
        if (odds.Count() == 1)
        {
            odd = odds.First().Key.ToString();
            occurences[odd[0]]--;
            if (occurences[odd[0]] == 0)
            {
                occurences.Remove(odd[0]);
            }
        }

        return String
               .Join("", occurences.Aggregate(
                        new List<char>(),
                        (acc, x) => {
                            acc.AddRange(Enumerable.Repeat(x.Key, x.Value / 2).ToList());
                            return acc;
                        }))
               .Permute()
               .Select(x => String
                            .Format(
                                "{0}{1}{2}",
                                x,
                                odd,
                                new String(x
                                           .Reverse()
                                           .ToArray())))
               .ToList();
    }

    static List<String> Permute(this String s)
    {
        if (s.Length == 1)
        {
            return new List<String> { s };
        }

        return Enumerable
               .Range(0, s.Length)
               .SelectMany(x => String
                                .Format(
                                    "{0}{1}", 
                                    s.Substring(0, x), 
                                    s.Substring(x + 1))
                                .Permute()
                                .Select(y => String.Format(
                                                      "{0}{1}",
                                                      s[x],
                                                      y)))
               .ToList();
    }

    static void Main()
    {
        Console.WriteLine(String.Join(", ", GeneratePalindromes("acabb")));
        Console.WriteLine(String.Join(", ", GeneratePalindromes("aabb")));
        Console.WriteLine(String.Join(", ", GeneratePalindromes("abc")));
    }
}
