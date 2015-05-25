# Binary tree traversals
#

class Node < Struct.new(:value, :left, :right)
end

class Tree
    def initialize(size)
        @root = fill(0, size - 1)
    end

    def fill(left, right)
        unless left > right
            mid = left + (right - left) / 2
            return Node.new(mid,
                            fill(left, mid - 1),
                            fill(mid + 1, right))
        end

        return nil
    end

    def inorder
        current = @root
        stack = []
        while !current.nil? || stack.any?
            if current.nil?
                current = stack.pop
                yield current
                current = current.right
            else
                stack.push(current)
                current = current.left
            end
        end
    end

    def preorder
        current = @root
        stack = []
        while !current.nil? || stack.any?
                current = stack.pop
                yield current
                stack.push(current.left) unless current.left.nil?
                stack.push(current.right) unless current.right.nil?
        end
    end

    private :fill
end

tree = Tree.new(15)
puts "--- Inorder ---"
tree.inorder {|x|
    puts x.value
}

puts "--- Preorder ---"
tree.preorder {|x|
    puts x.value
}

