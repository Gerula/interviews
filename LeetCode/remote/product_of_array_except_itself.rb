#   https://leetcode.com/problems/product-of-array-except-self/
#
#    Given an array of n integers where n > 1, nums, return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].
#
#    Solve it without division and in O(n).
#
#    For example, given [1,2,3,4], return [24,12,8,6].
#
#   https://leetcode.com/submissions/detail/53693653/
#
#   Submission Details
#   17 / 17 test cases passed.
#       Status: Accepted
#       Runtime: 220 ms
#           
#           Submitted: 0 minutes ago
#   
#   You are here!
#   Your runtime beats 4.35% of rubysubmissions. HAHAHAAAAHAHAAAA!!

def product_except_self(nums)
    (nums)
    .each_cons(2)
    .inject([1]) { |acc, x|
        acc << acc.last * x[0]
    }
    .zip((nums
         .reverse)
         .each_cons(2)
         .inject([1]) { |acc, x|
             acc << acc.last * x[0]
         }
         .reverse)
    .map.with_index { |x, i|
        x[0] * x[1] 
    }
end
