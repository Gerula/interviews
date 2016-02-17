#   https://leetcode.com/problems/binary-search-tree-iterator/
#   mplement an iterator over a binary search tree (BST). Your iterator will be initialized with the root node of a BST.
#
#   Calling next() will return the next smallest number in the BST.
#
#   Note: next() and hasNext() should run in average O(1) time and uses O(h) memory, where h is the height of the tree. 

#   https://leetcode.com/submissions/detail/53732227/
#
#   Submission Details
#   61 / 61 test cases passed.
#       Status: Accepted
#       Runtime: 100 ms
#           
#           Submitted: 1 minute ago
#   You are here!
#   Your runtime beats 80.00% of rubysubmissions.

class BSTIterator
    # @param {TreeNode} root
    def initialize(root)
        @current = root
        @stack = []
    end

    # @return {Boolean}
    def has_next
        while @stack.any? || !@current.nil?
            if @current.nil?
                @current = @stack.pop
                return true
            else
                @stack.push(@current)
                @current = @current.left
            end
        end
    end

    # @return {Integer}
    def next
        result = @current
        @current = @current.right unless @current.nil?
        return result.nil?? -1 : result.val
    end
end
