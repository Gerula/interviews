class Node < Struct.new(:value, :left, :right)
    def count_range(low, high)
        return Node::cunt_rage(self, low, high)
    end

    def self.cunt_rage(node, low, high)
        return 0 if node.nil?

        left = node.value < low ? 0 : Node::cunt_rage(node.left, low, high)
        right = node.value > high ? 0 : Node::cunt_rage(node.right, low, high)
        current = node.value.between?(low, high) ? 1 : 0

        return left + right + current
    end
end

root = Node.new(10,
                Node.new(5,
                         Node.new(1)),
                Node.new(50,
                         Node.new(40),
                         Node.new(100)))

puts root.count_range(5, 45)
