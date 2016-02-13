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

#   TLE Again. But this is the fucking solution
def coin_change(coins, amount)
    dp = Array.new(amount) { 0 }
    for i in 1..amount
        dp[i] = coins.select{ |x| x <= i }.map { |x| dp[i - x] + 1}.min || amount + 1
    end
    
    dp[amount].nil? || dp[amount] > amount ? -1 : dp[amount]
end
