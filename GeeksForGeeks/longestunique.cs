//  http://www.geeksforgeeks.org/length-of-the-longest-substring-without-repeating-characters/
//
//  Given a string, find the length of the longest substring without repeating characters.
//  For example, the longest substrings without repeating characters for “ABDEFGABEF” are “BDEFGA” and “DEFGAB”,
//  with length 6. For “BBBB” the longest substring is “B”, with length 1.
//  For “GEEKSFORGEEKS”, there are two longest substrings shown in the below diagrams, with length 7. 

using System;
using System.Collections;

static class Solution
{
    static int LongestUniq(this String s)
    {
        var maxLength = 0;
        var hash = new BitArray(255);
        var low = 0;
        var high = 0;
        while (high < s.Length)
        {
            if (hash[s[high]])
            {
                maxLength = Math.Max(maxLength, high - low);

                while (s[low] != s[high]) 
                {
                    hash[s[low]] = false;
                    low++;
                }

                low++;
            }
            else
            {
                hash[s[high]] = true;
            }

            high++;
        }

        return Math.Max(maxLength, s.Length - low);
    }

    static void Main()
    {
        Console.WriteLine("ABDEFGABEF".LongestUniq());
        Console.WriteLine("BBBB".LongestUniq());
        Console.WriteLine("GEEKSFORGEEKS".LongestUniq());
    }
}
