//  https://leetcode.com/problems/coin-change/
//
//   You are given coins of different denominations and a total amount of money amount. Write a function to compute the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1.
//
//   Example 1:
//   coins = [1, 2, 5], amount = 11
//   return 3 (11 = 5 + 5 + 1)
//
//   Example 2:
//   coins = [2], amount = 3
//   return -1.
//
//   Note:
//   You may assume that you have an infinite number of each kind of coin.

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    //  
    //  Submission Details
    //  180 / 180 test cases passed.
    //      Status: Accepted
    //      Runtime: 416 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //  https://leetcode.com/submissions/detail/49744360/
    //
    public int CoinChange(int[] coins, int amount) {
        var dp = new int[amount + 1];
        for (var i = 1; i <= amount; i++)
        {
            var min = int.MaxValue;
            foreach (var x in coins.Where(a => a <= i && dp[i - a] != -1))
            {
                min = Math.Min(min, dp[i - x] + 1);
            }

            dp[i] = min == int.MaxValue ? -1 : min;
        }

        return dp[amount];
    }

    // TLE and then Output limit exceeded
    public int CoinChange(int[] coins, int amount, Dictionary<int, int> cache = null) {
        if (amount == 0) {
            return 0;
        }
        
        if (cache == null) {
            cache = new Dictionary<int, int>();
        }
        
        if (!cache.ContainsKey(amount)) {
            cache[amount] = coins
                            .Where(x => x <= amount)
                            .Select(x => 1 + CoinChange(coins, amount - x, cache))
                            .DefaultIfEmpty(int.MaxValue)
                            .Min();
        }
        
        return cache[amount];
    }

    static void Main()
    {
        var s = new Solution();
        Console.WriteLine(s.CoinChange(new [] { 1, 2, 5 }, 11));
        Console.WriteLine(s.CoinChange(new [] { 1, 2, 5 }, 100));
        Console.WriteLine(s.CoinChange(new [] { 2 }, 3));
    }
}
