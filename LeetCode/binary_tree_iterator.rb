# Wrote this one directly in Leetcode

# Definition for a binary tree node.
# class TreeNode
#     attr_accessor :val, :left, :right
#     def initialize(val)
#         @val = val
#         @left, @right = nil, nil
#     end
# end

class BSTIterator
    # @param {TreeNode} root
    def initialize(root)
        @stack = []
        @current = root
        @node = root
    end

    # @return {Boolean}
    def has_next
        while @stack.any? || @current
            if @current.nil?
                @current = @stack.pop
                @node = @current
                @current = @current.right
                return true
            else
                @stack.push(@current)
                @current = @current.left
            end
        end
        
        return false
    end

    # @return {Integer}
    def next
        return @node.val
    end
end

# Your BSTIterator will be called like this:
# i, v = BSTIterator.new(root), []
# while i.has_next()
#    v << i.next
# end
