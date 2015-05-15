# You have two very large binary trees: T1, with millions of nodes, and T2, with hun- dreds of nodes. Create an algorithm to decide if T2 is a subtree of T1.
#

class Node < Struct.new(:value, :left, :right)
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
end

def fill(array, left, right)
    if left > right
        return
    end

    middle = left + (right - left) / 2
    return Node.new(array[middle],
                    fill(array, left, middle - 1),
                    fill(array, middle + 1, right))
end

tree_1 = fill([1, 2, 3, 4, 5, 6, 7, 8], 0, 8)
tree_2 = fill([1, 2, 3, 4, 5, 7], 0, 3)
puts tree_1.to_s_inorder + " " + tree_1.to_s_preorder
puts tree_2.to_s_inorder + " " + tree_2.to_s_preorder

puts tree_2.is_subtree(tree_1)
