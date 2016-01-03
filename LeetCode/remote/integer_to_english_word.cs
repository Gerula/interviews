//  https://leetcode.com/problems/integer-to-english-words/
//
//   Convert a non-negative integer to its english words representation.
//   Given input is guaranteed to be less than 231 - 1. 

using System;
using System.Collections.Generic;

public class Solution {
    String[] smallest = new [] { "Zero", "One", "Two", "Three", "Four", "Five",
                            "Six", "Seven", "Eight", "Nine", "Ten",
                            "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen",
                            "Sixteen", "Seventeen", "Eighteen", "Nineteen"};

    String[] tens = new [] { "", "Ten", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
    String[] large = new [] { "", "Thousand", "Million", "Billion" };

    //  
    //  Submission Details
    //  601 / 601 test cases passed.
    //      Status: Accepted
    //      Runtime: 60 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //      https://leetcode.com/submissions/detail/49544502/
    //
    public string NumberToWords(int num) {
        if (num == 0)
        {
            return smallest[num];
        }

        var order = 0;
        var result = String.Empty;
        while (num > 0)
        {
            if (num % 1000 != 0)
            {
                result = String.Format("{0}{1} {2}", Helper(num % 1000), large[order], result);
            }
            num /= 1000;
            order++;
        }

        return result.Trim();
    }

    public String Helper(int num)
    {
        if (num == 0)
        {
            return String.Empty;
        }

        if (num < 20)
        {
            return String.Format("{0} ", smallest[num]);
        }

        if (num < 100)
        {
            return String.Format("{0} {1}", tens[num / 10], Helper(num % 10));
        }

        return String.Format("{0} Hundred {1}", smallest[num / 100], Helper(num % 100));
    }

    static void Main()
    {
        var s = new Solution();
        var r = new Random();
        for (var i = 0; i < 10; i++)
        {
            var num = r.Next(1, int.MaxValue);
            Console.WriteLine("{0} = {1}|", num, s.NumberToWords(num));
        }
    }
}
