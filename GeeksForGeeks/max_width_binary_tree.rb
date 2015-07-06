class Node < Struct.new(:value, :left, :right)
    def max_width
        count = []
        max_w(self, 0, count)
        return count.max
    end

    def max_w(node, height, count)
        unless node.nil?
            count[height] ||= 0
            count[height] += 1
            max_w(node.left, height + 1, count)
            max_w(node.right, height + 1, count)
        end
    end
end

root = Node.new(1,
                Node.new(2,
                         Node.new(4),
                         Node.new(5)),
                Node.new(3,
                         Node.new(6,
                                  nil,
                                  Node.new(8)),
                         Node.new(7,
                                  nil,
                                  Node.new(9))))

puts root.max_width
