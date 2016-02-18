#   https://leetcode.com/problems/candy/
#
#    There are N children standing in a line. Each child is assigned a rating value.
#
#    You are giving candies to these children subjected to the following requirements:
#
#    Each child must have at least one candy.
#    Children with a higher rating get more candies than their neighbors.
#
#    What is the minimum candies you must give? 
#   
#   https://leetcode.com/submissions/detail/53776632/
#   Submission Details
#   28 / 28 test cases passed.
#       Status: Accepted
#       Runtime: 148 ms
#           
#           Submitted: 0 minutes ago

def candy(ratings)
    candies = Array.new(ratings.size) { 1 }
    1.upto(ratings.size - 1).each { |i|
        if ratings[i] > ratings[i - 1] && candies[i] <= candies[i - 1]
            candies[i] = candies[i - 1] + 1
        end
    }
    
    (ratings.size - 2).downto(0).each { |i|
        if ratings[i] > ratings[i + 1] && candies[i] <= candies[i + 1]
            candies[i] = candies[i + 1] + 1
        end
    }
    
    candies.inject(:+)
end
