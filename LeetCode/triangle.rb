# Given a triangle, find the minimum path sum from top to bottom. Each step you may move to adjacent numbers on the row below.
#
# For example, given the following triangle
#
# [
#   [2],
#   [3,4],
#   [6,5,7],
#   [4,1,8,3]
# ]
#
# The minimum path sum from top to bottom is 11 (i.e., 2 + 3 + 5 + 1 = 11). 
#

triangle = [
               [2],
               [3,4],
               [6,5,7],
               [4,1,8,3]
           ]

puts (1..triangle.size-1).inject(triangle[0]) { |agg, i|
    result = []
   
    (0..triangle[i].size-1).each { |x|
        min_1 = x == 0 ? 1000 : agg[x - 1]
        min_2 = x == triangle[i].size-1 ? 1000 : agg[x]
        result << triangle[i][x] + [min_1, min_2].min     
    }

    result
}.min
