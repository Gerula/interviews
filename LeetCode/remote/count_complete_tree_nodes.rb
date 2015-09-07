# https://leetcode.com/problems/count-complete-tree-nodes/

require 'test/unit'
extend Test::Unit::Assertions

class TreeNode
    attr_accessor :val, :left, :right
    def initialize(val, left, right)
        @val = val
        @left, @right = left, right
    end
end

def count_nodes(root)
    left = measure(root, :left)
    right = measure(root, :right)
    return 2 ** left - 1 if left == right
    max = left
    diff = 0
    current = root
    while current
        diff += 1
        current = current.left
        left -= 1
        right = measure(current, :right)
        return 2 ** max - 1 - diff if left == right
    end

    return -1
end

def measure(root, direction)
    current = root
    count = 0
    while current
        count += 1
        case direction
            when :left then current = current.left
            when :right then current = current.right
        end
    end

    return count
end

root = TreeNode.new(4,
                    TreeNode.new(2,
                                 TreeNode.new(1, nil, nil),
                                 TreeNode.new(3, nil, nil)),
                    TreeNode.new(5,
                                 TreeNode.new(6, nil, nil), nil))

assert_equal(6, count_nodes(root))
