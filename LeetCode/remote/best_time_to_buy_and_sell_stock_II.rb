#   https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/
#   Say you have an array for which the ith element is the price of a given stock on day i.
#
#   Design an algorithm to find the maximum profit.
#   You may complete as many transactions as you like (ie, buy one and sell one share of the stock multiple times).
#   However, you may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
#   https://leetcode.com/submissions/detail/54053629/
#
#   Submission Details
#   198 / 198 test cases passed.
#       Status: Accepted
#       Runtime: 84 ms
#           
#           Submitted: 0 minutes ago

def max_profit(prices)
    prices.each_cons(2).map { |x, y| y - x }.select { |x| x >= 0 }.reduce(:+) || 0
end
