# https://leetcode.com/submissions/detail/38083590/
#
# 32 / 32 test cases passed.
#   Status: Accepted
#   Runtime: 252 ms
#       
#       Submitted: 0 minutes ago
#
#       You are here!
#       Your runtime beats 66.67% of ruby coders. <- need to do better than this

require 'test/unit'
extend Test::Unit::Assertions

class TreeNode
     attr_accessor :val, :left, :right
     def initialize(val)
         @val = val
         @left, @right = nil, nil
     end

     def serialize
         return "#{@val} #{@left.nil? ? "nil" : @left.serialize} #{@right.nil? ? "nil" : @right.serialize}"
     end
end

def sorted_array_to_bst(nums)
    return array_to_bst(nums, 0, nums.size - 1)
end

def array_to_bst(nums, low, high)
    return nil if low > high
    mid = low + (high - low) / 2
    tree = TreeNode.new(nums[mid])
    tree.left = array_to_bst(nums, low, mid - 1)
    tree.right = array_to_bst(nums, mid + 1, high)
    return tree
end

assert_equal("3 1 nil 2 nil nil 4 nil 5 nil nil", sorted_array_to_bst([1, 2, 3, 4, 5]).serialize)
assert_equal("2 1 nil nil 3 nil 4 nil nil", sorted_array_to_bst([1, 2, 3, 4]).serialize)
