//  https://leetcode.com/problems/candy/
//
//   There are N children standing in a line. Each child is assigned a rating value.
//
//   You are giving candies to these children subjected to the following requirements:
//
//       Each child must have at least one candy.
//           Children with a higher rating get more candies than their neighbors.
//
//           What is the minimum candies you must give? 

using System;

public class Solution {
    //  
    //  Submission Details
    //  28 / 28 test cases passed.
    //      Status: Accepted
    //      Runtime: 192 ms
    //          
    //          Submitted: 0 minutes ago
    //
    public int Candy(int[] ratings) {
        var n = ratings.Length;
        if (n < 2)
        {
            return n;
        }

        var candies = new int[n];
        candies[0] = 1;
        for (var i = 1; i < n; i++)
        {
            candies[i] = ratings[i] > ratings[i - 1] ? candies[i - 1] + 1 : 1;
        }

        var candy = candies[n - 1];
        for (var i = n - 2; i >= 0; i--)
        {
            if (ratings[i] > ratings[i + 1] && candies[i] < candies[i + 1] + 1)
            {
                candies[i] = candies[i + 1] + 1;
            }

            candy += candies[i];
        }

        return candy;
    }

    static void Main()
    {
        Console.WriteLine(new Solution().Candy(new [] { 3, 7, 1, 2, 3, 4, 1 }));
        Console.WriteLine(new Solution().Candy(new [] { 2, 2 }));
    }
}
