# Our task today is to generate a set of k random positive integers that add up to a given totaln. For instance, if we want 4 random numbers that add up to 9, there are six possible results (not counting permutations of them): {6,1,1,1}, {5,2,1,1}, {4,3,1,1}, {4,2,2,1}, {3,3,2,1} and {3,2,2,2}.
#
# An easy way to do that is to choose k−1 random numbers r with 0 ≤ r < n−k, sort them, calculate the differences between them, calculate the difference between 0 and the smallest, calculate the difference between n−k and the largest, shuffle the differences, and add 1 to each; subtracting k and adding 1 ensures that all the numbers are positive. For our example above, choose three random non-negative integers less than n−k = 5, say 1, 3, and 3, the differences are 1, 2, 0 and 2, and the four resulting numbers are 2, 3, 1 and 3, which form the fifth of the six sets shown above.
#

k = 4
sum = 9

diff = 1.upto(k - 1).each.map{ |x| Random.rand(0..(sum - k - 1))}.sort
min = diff.min
max = diff.max
diff = [diff.min] + diff.reverse.each_cons(2).map{|a, b| a - b } + [sum - k - max]
diff.map!{ |x| x + 1 }
puts diff.inspect
