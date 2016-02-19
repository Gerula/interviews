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

#   Very nice (genius) solution using a state machine
#   So every index can be in 3 states: buy, sell, rest and you need to compute the local
#   optimum for each state. Very VERY nice solution
#   
#   Submission Details
#   212 / 212 test cases passed.
#       Status: Accepted
#       Runtime: 108 ms
#           
#           Submitted: 0 minutes ago
#
#   https://leetcode.com/submissions/detail/53925030/
# @param {Integer[]} prices
# @return {Integer}
def max_profit(prices)
    return 0 if prices.size < 2
    buy = Array.new(prices.size - 1) { 0 }
    sell = Array.new(prices.size - 1) { 0 }
    rest = Array.new(prices.size - 1) { 0 }
    buy[0] = -prices[0]
    rest[0] = 0
    sell[0] = 0
    for i in 1...prices.size
        rest[i] = [rest[i - 1], sell[i - 1]].max
        buy[i] = [buy[i - 1], rest[i - 1] - prices[i]].max
        sell[i] = buy[i - 1] + prices[i]
    end
    
    [rest[prices.size - 1], sell[prices.size - 1]].max
end
