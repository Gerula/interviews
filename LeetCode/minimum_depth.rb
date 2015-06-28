class Node < Struct.new(:value, :left, :right)
    def min_h
        min_h_rec(self)
    end

    def min_h_rec(node)
        return 0 if node.nil?
        return [min_h_rec(node.left), min_h_rec(node.right)].min + 1
    end

    private :min_h_rec
end

node = Node.new(1,
                Node.new(2,
                         Node.new(3)),
                Node.new(4))

puts node.min_h
