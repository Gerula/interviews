#   https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-cooldown/
#
#   Say you have an array for which the ith element is the price of a given stock on day i.
#
#   Design an algorithm to find the maximum profit. You may complete as many transactions as you like (ie, buy one and sell one share of the stock multiple times) with the following restrictions:
#
#   You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
#   After you sell your stock, you cannot buy stock on next day. (ie, cooldown 1 day)

#   TLE???
# @param {Integer[]} prices
# @return {Integer}
def max_profit(prices)
    profit = Array.new(prices.length + 2) { 0 }
    return 0 if prices.size < 2
    (prices.size - 2).downto(0).each { |i|
        price = prices[i]
        profit[i] = 0
        (i + 1).upto(prices.size - 1).each { |j|
            profit[i] = [profit[i], prices[j] - price + profit[j + 2]].max
        }

        profit[i] = profit[i] >= 0 ? profit[i] : 0
    }

    profit[0]
end
