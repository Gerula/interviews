#
#
#              1
#             / \
#            2   7 
#           / \   \
#          3   4   8
#               \   \
#                5   9
#               /   /
#              6  10
#                  \
#                   11
#

class Node < Struct.new(:value, :left, :right)
    def self.Build(preorder, inorder)
        return nil if preorder.empty? || inorder.empty?
        root_value = preorder.first
        root_index = inorder.index(root_value)
        return Node.new(root_value,
                        self.Build(preorder[1, root_index], inorder[0, root_index]),
                        self.Build(preorder[1 + root_index, preorder.size - root_index - 1], inorder[1 + root_index, inorder.size - root_index - 1]))
    end

    def preorder
        "#{value} #{left ? left.preorder : nil}#{right ? right.preorder : nil}"
    end

    def inorder
        "#{left ? left.inorder : nil} #{value}#{right ? right.inorder : nil}"
    end
end

root = Node::Build([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11], [3, 2, 4, 5, 6, 1, 7, 8, 9, 10, 11])
puts root.inorder
puts root.preorder


