# @param {Integer[]} prices
# @return {Integer}
def max_profit(prices)
    return 0 if prices.empty? || prices.size == 1
    min = prices[0]
    profit = 0
    for i in 1...prices.size
        profit = [prices[i] - min, profit].max
        min = [prices[i], min].min
    end
    
    return profit
end
