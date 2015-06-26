class Node < Struct.new(:value, :left, :right)
    def search(value)
        return search_rec(self, value)
    end

    def search_rec(root, value)
        return nil if root.nil?
        return nil if value < root.value
        return root if value == root.value
        left = search_rec(root.left, value)
        right = search_rec(root.right, value)
        return left if left
        return right if right
    end
end

node = Node.new(2,
                Node.new(3,
                         nil,
                         Node.new(5,
                                  Node.new(7, nil, nil),
                                  Node.new(11, nil, nil))),
                Node.new(13,
                         Node.new(17, nil, nil),
                         Node.new(19,
                                  Node.new(23, nil, nil),
                                  nil)))

[2, 3, 5, 13, 17, 23, 22, 0, -1, 15].each { |x|
    puts "#{x} - #{node.search(x)}"
}
