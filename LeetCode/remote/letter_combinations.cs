//  https://leetcode.com/problems/letter-combinations-of-a-phone-number/
//
//  Given a digit string, return all possible letter combinations that the number could represent.
//
//  A mapping of digit to letters (just like on the telephone buttons) is given below.

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    static Dictionary<char, List<String>> Map = new Dictionary<char, List<String>> {
        { '1', new List<String> { String.Empty }},
        { '2', new List<String> { "a", "b", "c" }},
        { '3', new List<String> { "d", "e", "f" }},
        { '4', new List<String> { "g", "h", "i" }},
        { '5', new List<String> { "j", "k", "l" }},
        { '6', new List<String> { "m", "n", "o" }},
        { '7', new List<String> { "p", "q", "r", "s" }},
        { '8', new List<String> { "t", "u", "v" }},
        { '9', new List<String> { "w", "x", "y", "z" }},
        { '0', new List<String> { " " }}
    };

    //  
    //  Submission Details
    //  25 / 25 test cases passed.
    //      Status: Accepted
    //      Runtime: 536 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //  https://leetcode.com/submissions/detail/53000041/
    //
    public IList<string> LetterCombinations(string digits) {
        if (String.IsNullOrEmpty(digits))
        {
            return new List<String>();
        }

        if (digits.Length == 1)
        {
            return Map[digits[0]];
        }

        return Map[digits[0]]
               .SelectMany(digit => LetterCombinations(digits.Substring(1))
                                    .Select(x => digit + x))
               .ToList();
    }

    static void Main()
    {
        Console.WriteLine(String.Join(", ", new Solution().LetterCombinations("23")));
    }
}
