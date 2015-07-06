class Node < Struct.new(:value, :left, :right)
    def self.delete_singles(node)
        return nil if node.nil?
        return node if node.left.nil? && node.right.nil?
        node.right = self.delete_singles(node.right) if !node.right.nil?
        node.left = self.delete_singles(node.left) if !node.left.nil?
        if !node.right.nil? && !node.left.nil?
            return node
        end

        return node.left if !node.left.nil?
        return node.right if !node.right.nil?
    end

    def self.inorder(node)
        unless node.nil?
            self.inorder(node.left)
            puts "#{node.value} #{node.left.nil? ? "nil" : node.left.value} #{node.right.nil? ? "nil" : node.right.value}"
            self.inorder(node.right)
        end
    end
end

root = Node.new(2,
                Node.new(7,
                         nil,
                         Node.new(6,
                                  Node.new(1),
                                  Node.new(11))),
                Node.new(5,
                         nil,
                         Node.new(9,
                                  Node.new(4))))

Node::inorder(root)
puts
root = Node::delete_singles(root)
Node::inorder(root)

