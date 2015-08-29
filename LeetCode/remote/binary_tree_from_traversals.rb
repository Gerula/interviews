# https://leetcode.com/submissions/detail/37975431/
#
# 202 / 202 test cases passed.
#   Status: Accepted
#   Runtime: 128 ms
#       
#       Submitted: 0 minutes ago
#
#       You are here!
#       Your runtime beats 100.00% of ruby coders.

class TreeNode < Struct.new(:val, :left, :right)
    def inorder
        return "#{left.nil? ? "" : left.inorder} #{self.val} #{right.nil? ? "" : right.inorder}"
    end
end

def build_tree(inorder, postorder)
    return nil if inorder.nil? || postorder.nil? ||
                  inorder.empty? || postorder.empty? ||
                  inorder.size != postorder.size
    
    root = TreeNode.new(postorder.last)
    inorder_position = inorder.index(root.val)
    root.left = build_tree(inorder[0...inorder_position], postorder[0, inorder_position])
    root.right = build_tree(inorder[(inorder_position + 1)..-1], postorder[inorder_position...-1])
    return root
end

puts build_tree([4, 2, 5, 1, 6, 7, 3, 8], [4, 5, 2, 6, 7, 8, 3, 1]).inorder

