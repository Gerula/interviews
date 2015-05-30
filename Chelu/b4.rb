#  Output the elements of a binary search tree in order. Follow up: Given the root node and another node of the BST, find the next node in order. 
#

class Node < Struct.new(:value, :left, :right)
end

class Tree 
    def initialize
        @root = fill(0, 10)
    end

    def fill(l, r)
        return nil if l > r
        m = l + (r - l) / 2
        return Node.new(m,
                        fill(l, m - 1),
                        fill(m + 1, r))
    end

    def inorder(next_node = nil)
        stack = []
        current = @root
        found = false
        while current || stack.any?
            if current
                stack.push(current)
                current = current.left
            else
                current = stack.pop
                print "#{current.value} "
                if found
                    return current
                end
                if next_node == current.value
                    found = true
                end
                current = current.right
            end
        end
        puts 
    end

    def next_node(node)
        puts inorder(node)
    end

    def next_node_2(node)
        puts node.value
        if node.right
            current = node.right
            while current.left
                current = current.left
            end
            return current
        end

        current = @root
        next_node = @root
        while current
            if node.value < current.value
                next_node = current
                current = current.left
            elsif node.value > current.value
                current = current.right
            else
                return current
            end
        end

        return current
    end
    attr_accessor :root
end

tree = Tree.new
tree.inorder
puts tree.next_node(1)
puts tree.next_node_2(tree.root.left)
