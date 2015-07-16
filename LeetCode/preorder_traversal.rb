class Node < Struct.new(:value, :left, :right)
    def to_s
        return "#{self.left.nil? ? "" : self.left.to_s}#{self.value} #{self.right.nil? ? "" : self.right.to_s}" 
    end

    def self.fill(low, high)
        return nil if low > high
        mid = low + (high - low) / 2
        return Node.new(mid,
                        fill(low, mid - 1),
                        fill(mid + 1, high))
    end

    def preorder_rec
        return " #{self.value}#{self.left.nil? ? "" : self.left.preorder_rec}#{self.right.nil? ? "" : self.right.preorder_rec}"
    end
end

root = Node::fill(1, 10)
puts root
puts root.preorder_rec

stack = [root]
while stack.any?
    current = stack.pop
    print "#{current.value} "
    stack.push(current.right) unless current.right.nil?
    stack.push(current.left) unless current.left.nil?
end
puts



