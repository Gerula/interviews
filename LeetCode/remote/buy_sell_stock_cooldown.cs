// https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-cooldown/
//
// Say you have an array for which the ith element is the price of a given stock on day i.
//
// Design an algorithm to find the maximum profit. You may complete as many transactions as you like (ie, buy one and sell one share of the stock multiple times) with the following restrictions:
//
// You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
// After you sell your stock, you cannot buy stock on next day. (ie, cooldown 1 day)
//

using System;

public class Solution {
    public int MaxProfit(int[] prices) {
        return MaxProfitHelper(prices, 0);
    }

    public int MaxProfitHelper(int[] prices, int start) 
    {
        if (start >= prices.Length - 1)
        {
            return 0;
        }

        var buy = prices[start];
        var max = int.MinValue;
        for (var i = start + 1; i < prices.Length; i++)
        {
            if (prices[i] > buy)
            {
                var localMax = prices[i] - buy;
                max = Math.Max(max, localMax + MaxProfitHelper(prices, i + 2));
            }
        }

        return max;
    }

    static void Main()
    {
        Console.WriteLine(new Solution().MaxProfit(new [] {1, 2, 3, 0, 2}));
    }
}
