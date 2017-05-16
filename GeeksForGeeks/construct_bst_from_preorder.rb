#   http://www.geeksforgeeks.org/construct-bst-from-given-preorder-traversa/
#   Given preorder traversal of a binary search tree, construct the BST.

require 'test/unit'
extend Test::Unit::Assertions

class Node < Struct.new(:val, :left, :right)
    def preorder
        return [self.val] + 
               (self.left.nil? ? [] : self.left.preorder) +
               (self.right.nil? ? [] : self.right.preorder)
    end
end

def construct(a)
    return nil if a.empty? || a.nil?
    pivot = Random.rand(a.size)
    return Node.new(a[pivot],
                    construct(a[0...pivot]),
                    construct(a[pivot + 1..-1]))
end

def reconstruct(a)
    root = Node.new(a.first)
    stack = [root]
    a.drop(1).each { |x|
        node = nil
        while stack.any? && stack.last.val < x
            node = stack.pop
        end

        if node.nil?
            stack.last.left = Node.new(x)
            stack.push(stack.last.left)
        else
            node.right = Node.new(x)
            stack.push(node.right)
        end
    }
    
    root
end

def same_tree(a, b)
    return a == b if a.nil? || b.nil?
    return a.val == b.val && 
           same_tree(a.left, b.left) &&
           same_tree(a.right, b.right)
end

tree = construct((1...2000).to_a)
assert(same_tree(tree, reconstruct(tree.preorder)))
