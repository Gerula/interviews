#  Given a binary tree, determine if it is a valid binary search tree (BST). 
#

class Node < Struct.new(:value, :left, :right)
end

class Tree
    attr_accessor :root

    def initialize(size)
        @root = fill(0, size)
    end

    def fill(left, right)
        return nil if left > right
        mid = left + (right - left) / 2
        return Node.new(mid,
                        fill(left, mid - 1),
                        fill(mid + 1, right))
    end

    def inspect
        stack = []
        current = @root
        while stack.any? || !current.nil?
            if current.nil?
                current = stack.pop
                print "#{current.value} "
                current = current.right
            else
                stack.push(current)
                current = current.left
            end
        end

        puts
    end

    def is_bst?
        return is_bst_recursive(@root,-1, 100)
    end

    def is_bst_recursive(current, min, max)
        return current.nil? ||
               current.value.between?(min, max) &&
               is_bst_recursive(current.left, min, current.value) &&
               is_bst_recursive(current.right, current.value, max)
    end

    private :fill
    private :is_bst_recursive
end

tree = Tree.new(10)
tree.inspect
puts tree.is_bst?
tree.root.left.value = 10
tree.inspect
puts tree.is_bst?
