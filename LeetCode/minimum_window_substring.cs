//  Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).
//
//  For example,
//  S = "ADOBECODEBANC"
//  T = "ABC"
//
//  Minimum window is "BANC". 
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program 
{
    private static string MinWindow(string text, string pattern)
    {
        HashSet<Char> hunted = new HashSet<Char>(pattern.ToArray().Distinct());
        Dictionary<Char, int> found = new Dictionary<Char, int>();
        int left = 0;
        int right = 0;
        int minLeft = 0;
        int minRight = text.Length;
        for (int i = 0; i < text.Length; i++)
        {
            char currentLetter = text[i];
            
            if (hunted.Contains(currentLetter))
            {
                int oldCount = 0;
                found.TryGetValue(currentLetter, out oldCount);
                found[currentLetter] = oldCount + 1;
            }

            if ((found.Count == hunted.Count) && 
                hunted.Contains(currentLetter) &&
                (text[left] == currentLetter))
            {
                right = i;
                while (!found.ContainsKey(text[left]) || found[text[left]] > 1)
                {
                    if (found.ContainsKey(text[left]))
                    {
                        found[text[left]]--;
                    }

                    left++;
                }

                if ((right - left) < (minRight - minLeft))
                {
                    minRight = right;
                    minLeft = left;
                }
            }
        }
       
        return text.Substring(left, right - left + 1);
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(MinWindow("ADOBECODEBANC", "ABC"));    
    }
}
