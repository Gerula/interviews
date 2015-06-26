class Node < Struct.new(:value, :left, :right, :left_count, :right_count)
    def self.Fill(left, right)
        return nil if left > right
        mid = left + (right - left) / 2
        node =  Node.new(mid,
                self.Fill(left, mid - 1),
                self.Fill(mid + 1, right))
        node.left_count = node.left ? node.left.left_count + node.left.right_count + 1 : 0
        node.right_count = node.right ? node.right.left_count + node.right.right_count + 1 : 0
        return node
    end

    def inorder(lambda)
        inorder_rec(self, lambda)
    end

    def inorder_rec(root, lambda)
        unless root.nil?
            inorder_rec(root.left, lambda)
            lambda.call(root)
            inorder_rec(root.right, lambda)
        end
    end

    def largest(k)
    end
end

node = Node::Fill(1, 10)
node.inorder( -> (x) { print "#{x.value} [#{x.left_count}-#{x.right_count}] " })
puts

