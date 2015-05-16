class Node < Struct.new(:value, :left, :right, :subtreehash)
    require 'stringio'
 
    def to_s_inorder
        stack = []
        result = StringIO.new
        current = self
        while stack.any? || !current.nil?
            if current.nil?
                current = stack.pop
                result << current.value
                current = current.right
            else
                stack.push(current)
                current = current.left
            end
        end
 
        return result.string
    end
 
    def to_s_preorder
        stack = []
        result = StringIO.new
        current = self
        while stack.any? || !current.nil?
            if current.nil?
                current = stack.pop
            else
                result << current.value
                stack.push(current.right) unless current.right.nil?
                current = current.left
            end
        end
 
        return result.string
    end
 
    def is_subtree(other)
        other.to_s_preorder.include?(to_s_preorder) &&
        other.to_s_inorder.include?(to_s_inorder)
    end
     
    def inorder
        inorder(self)
    end
     
    def inorder(root)
        if root.nil?
            return
        end
         
        inorder(root.left)
        puts "#{root.value} - hash #{root.subtreehash}"
        inorder(root.right)
    end
     
    def contains_subtree?(other)
        return do_contains_subtree?(self, other)
    end
     
    def do_contains_subtree?(root, other)
        if root == nil
            return false
        end
         
        return root.subtreehash == other.subtreehash || 
               do_contains_subtree?(root.left, other) || 
               do_contains_subtree?(root.right, other)
    end
end
 
 
def fill(array, left, right)
    if left > right
        return
    end
 
    middle = left + (right - left) / 2
    newNode = Node.new(array[middle], fill(array, left, middle - 1), fill(array, middle + 1, right))
    leftHash = newNode.left.nil? ? 0 : newNode.left.subtreehash
    rightHash = newNode.right.nil? ? 0 : newNode.right.subtreehash
    newNode.subtreehash = newNode.value.hash + leftHash + rightHash
    return newNode
end
 
tree_1 = fill([1, 2, 3, 4, 5, 6, 7, 8], 0, 8)
tree_2 = fill([1, 2, 3, 4, 5, 7], 0, 3)
#puts tree_1.to_s_inorder + " " + tree_1.to_s_preorder
#puts tree_2.to_s_inorder + " " + tree_2.to_s_preorder
#puts tree_2.is_subtree(tree_1)
puts tree_1.contains_subtree?(tree_2)
