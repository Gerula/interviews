# coding: utf-8
#   https://leetcode.com/problems/counting-bits/
#   Given a non negative integer number num.
#   For every numbers i in the range 0 ≤ i ≤ num calculate the number of 1's in their binary representation and return them as an array. 
#   https://leetcode.com/submissions/detail/56651730/
#
#   Submission Details
#   16 / 16 test cases passed.
#       Status: Accepted
#       Runtime: 624 ms
#           
#           Submitted: 0 minutes ago
#   Basically Gray Code idea.
# @param {Integer} num
# @return {Integer[]}
def count_bits(num)
    counts = [0]
    while counts.length < num + 1
        counts += counts.map { |x| x + 1 }
    end

    counts[0..num]
end

puts "haha"
