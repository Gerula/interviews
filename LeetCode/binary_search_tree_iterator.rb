# Implement an iterator over a binary search tree (BST). Your iterator will be initialized with the root node of a BST.
#
# Calling next() will return the next smallest number in the BST.
#
# Note: next() and hasNext() should run in average O(1) time and uses O(h) memory, where h is the height of the tree. 
#

class Node < Struct.new(:value, :left, :right)
end

def fill(a, left, right)
    if left > right
        return nil
    end

    mid = left + (right - left) / 2
    return Node.new(a[mid], 
                    fill(a, left, mid - 1),
                    fill(a, mid + 1, right))
end

class Tree
    def initialize(root)
        @root = root
        @current = max
    end

    def inorder
        inorder_internal(@root)
    end

    def each
        current = @root
        stack = []
        while stack.any? || !current.nil?
            if current.nil?
                current = stack.pop
                yield current
                current = current.left
            else
                stack.push(current)
                current = current.right
            end
        end
    end

    def inorder_internal(root)
        unless root.nil?
            inorder_internal(root.left)
            puts(root.value)
            inorder_internal(root.right)
        end
    end

    def max
        it = @root
        while !it.right.nil?
            puts it.right
            it = it.right
        end
        return it
    end

    private :inorder_internal
end


tree = Tree.new(fill([1, 2, 3, 4, 5, 6, 7, 8], 0, 7))
tree.inorder
puts tree.max.value

tree.each {|x|
    puts "#{x.value} - iterator"
}
