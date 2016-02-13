#   https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/
#
#   Given an array where elements are sorted in ascending order, convert it to a height balanced BST.

#   
#   Submission Details
#   32 / 32 test cases passed.
#       Status: Accepted
#       Runtime: 264 ms
#           
#           Submitted: 0 minutes ago
#   
#   https://leetcode.com/submissions/detail/53340045/

def sorted_array_to_bst(nums)
    return nil if nums.nil? || !nums.any?
    node = TreeNode.new(nums[nums.size / 2])
    node.left = sorted_array_to_bst(nums[0...nums.size / 2])
    node.right = sorted_array_to_bst(nums[nums.size / 2 + 1..-1])
    return node
end


