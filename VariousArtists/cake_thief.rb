#   Each type of cake has a weight and a value, stored in a tuple with two indices:
#
#       An integer representing the weight of the cake in kilograms
#       An integer representing the monetary value of the cake in British pounds
#   
#   Write a function max_duffel_bag_value() that takes a list of cake type tuples and a weight capacity,
#   and returns the maximum monetary value the duffel bag can hold.

#   cake_tuples = [(7, 160), (3, 90), (2, 15)]
#   capacity    = 20
#
#   max_duffel_bag_value(cake_tuples, capacity)
#   # returns 555 (6 of the middle type of cake and 1 of the last type of cake)

def max_value(cakes, capacity)
    return 0 if capacity == 0
    max = 0
    cakes.keys
    .select { |x| x <= capacity }
    .each { |x|
        max = [max, max_value(cakes, capacity - x) + cakes[x]].max    
    }

    max
end

def max_value_2(cakes, capacity)
    dp = Array.new(capacity + 1) { -2 ** (0.size * 8 - 2) }
    dp[0] = 0
    1.upto(capacity).each { |cap|
        dp[cap] = cakes.keys
                  .select { |x| x <= cap }
                  .map { |x| dp[cap - x] + cakes[x] }
                  .max || dp[cap]
    }

    dp[capacity]
end

puts max_value({7 => 160, 3 => 90, 2 => 15}, 20)
puts max_value_2({7 => 160, 3 => 90, 2 => 15}, 20)
