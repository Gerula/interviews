# http://www.geeksforgeeks.org/print-common-nodes-in-two-binary-search-trees/
# Given two Binary Search Trees, find common nodes in them. In other words, find intersection of two BSTs.

require 'test/unit'
extend Test::Unit::Assertions

class Node < Struct.new(:value, :left, :right)
    def inorder(result)
        self.left.inorder(result) unless self.left.nil?
        result << self.value
        self.right.inorder(result) unless self.right.nil?
    end
end

tree_1 = Node.new(5,
                  Node.new(1,
                           Node.new(0),
                           Node.new(4)),
                  Node.new(10,
                           Node.new(7,
                                    nil,
                                    Node.new(9))))

tree_2 = Node.new(10,
                  Node.new(7,
                           Node.new(4),
                           Node.new(9)),
                  Node.new(20))

def common_nodes(tree_1, tree_2)
    nodes_1 = []
    tree_1.inorder(nodes_1) unless tree_1.nil?

    nodes_2 = []
    tree_2.inorder(nodes_2) unless tree_2.nil?

    result = []
    i, j = 0, 0
    while i < nodes_1.size && j < nodes_2.size
        if nodes_1[i] == nodes_2[j]
            result << nodes_1[i]
            i += 1
            j += 1
        elsif nodes_1[i] < nodes_2[j]
            i += 1
        else
            j += 1
        end
    end

    return result
end

assert_equal([4, 7, 9, 10], common_nodes(tree_1, tree_2))
