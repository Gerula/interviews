#   https://leetcode.com/problems/coin-change/
#
#   You are given coins of different denominations and a total amount of money amount. Write a function to compute the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1.
#

#   TLE

def coin_change(coins, amount)
    return 0 if amount == 0
    return coins.size if amount < 0
    return coins.map { |x| coin_change(coins, amount - x) + 1 }.min
end
