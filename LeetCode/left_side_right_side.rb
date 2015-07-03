class Node < Struct.new(:value, :left, :right)
    def self.fill(low, high)
        return nil if low > high
        mid = low + (high - low) / 2
        return Node.new(mid, Node::fill(low, mid - 1), Node::fill(mid + 1, high))
    end

    def display
        Node::inorder(self)
        puts
    end

    def self.inorder(node)
        unless node.nil?
            inorder(node.left)
            print "#{node.value} "
            inorder(node.right)
        end
    end

    def n_th(n)
        input = [n, nil]
        Node::nth(self, input)
        return input[1]
    end

    def self.nth(root, input)
        Node::nth(root.left, input) unless root.left.nil?
        input[0] -= 1
        input[1] = root if input[0] == 0
        Node::nth(root.right, input) unless root.right.nil?
    end

    def left_side
        left_rec(self, [0], 1)
        puts
    end

    def left_rec(node, level, current_level) 
        unless node.nil?
            if level[0] < current_level
                print "#{node.value} "
                level[0] = current_level
            end
            
            left_rec(node.left, level, current_level + 1)
            left_rec(node.right, level, current_level + 1)
        end
    end
end

root = Node::fill(1, 10)
root.display
puts root.n_th(1)
it = root
while it
    print "#{it.value} "
    it = it.left
end
puts 

root.left_side
