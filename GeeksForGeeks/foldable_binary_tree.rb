class Node < Struct.new(:value, :left, :right)
    def foldable?
        return fold(self.left, self.right)
    end

    def fold(left, right)
        if left.nil? || right.nil?
            return left.nil? && right.nil?
        end

        return fold(left.left, right.right) && fold(left.right, right.left) 
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

root2 = Node.new(1,
                 Node.new(2,
                          nil,
                          Node.new(3)),
                 Node.new(4,
                          Node.new(5)))


puts root.foldable?
puts root2.foldable?
