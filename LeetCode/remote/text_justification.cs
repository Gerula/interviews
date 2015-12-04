//  https://leetcode.com/problems/text-justification/
//
//  Given an array of words and a length L,
//  format the text such that each line has exactly L characters and is fully (left and right) justified.
//
//  You should pack your words in a greedy approach;
//  that is, pack as many words as you can in each line.
//  Pad extra spaces ' ' when necessary so that each line has exactly L characters.
//
//  Extra spaces between words should be distributed as evenly as possible.
//  If the number of spaces on a line do not divide evenly between words,
//  the empty slots on the left will be assigned more spaces than the slots on the right.
//
//  For the last line of text, it should be left justified and no extra space is inserted between words. 

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public IList<string> FullJustify(string[] words, int maxWidth) 
    {
        var n = words.Length;
        var penalty = new int[n + 1, n + 1];
        var lengths = new int[n, n];

        for (var i = 0; i < n; i++)
        {
            for (var j = i; j < n; j++)
            {
                lengths[i, j] = i == j ? words[i].Length : lengths[i, j - 1] + 1 + words[j].Length;
                penalty[i, j] = lengths[i, j] < maxWidth ? (int) Math.Pow(maxWidth - lengths[i, j], 3) : int.MaxValue;
            }
        }

        var parent = new int[n + 1];
        var cost = new int[n + 1];
        for (var i = n; i >= 0; i--)
        {
            var min = int.MaxValue;
            for (var j = i; j < n + 1; j++)
            {
                var localCost = penalty[i, j] == int.MaxValue ? int.MaxValue : penalty[i, j] + cost[j];
                if (localCost < min)
                {
                    min = penalty[i, j];
                    parent[j] = i;
                }
            }
            
            cost[i] = min;
        }

        return result;
    }

    static void Main()
    {
        var s = new Solution();
        Console.WriteLine(
                String.Join(
                    Environment.NewLine, 
                    s.FullJustify(new [] {"This", "is", "an", "example", "of", "text", "justification."}, 16)));
    }
}
