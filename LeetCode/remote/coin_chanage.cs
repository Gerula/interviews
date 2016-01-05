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
using System.Linq;

public class Solution {
    public int CoinChange(int[] coins, int amount) {
        if (amount == 0)
        {
            return 0;
        }

        var forward = coins
                      .Where(x => x < amount)
                      .Select(x => CoinChange(coins, x - amount))
                      .Where(x => x != -1);

        return forward.Any() ? forward.Min() + 1 : -1;
    }

    static void Main()
    {
        var s = new Solution();
        Console.WriteLine(s.CoinChange(new [] { 1, 2, 5 }, 11));
        Console.WriteLine(s.CoinChange(new [] { 2 }, 3));
    }
}
