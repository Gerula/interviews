class Node < Struct.new(:value, :left, :right, :next)
    def self.fill(low, high)
        return nil if low > high
        mid = low + (high - low) / 2
        return Node.new(mid,
                        self.fill(low, mid - 1),
                        self.fill(mid + 1, high))
    end

    def inorder
        self.left.inorder unless self.left.nil?
        puts "#{self.value} #{self.next.nil? ? nil : self.next.value}"
        self.right.inorder unless self.right.nil?
    end

    def fix_next
        if self.next
            self.next.fix_next
        end

        if self.left
            self.left.next = self.right
        end

        if self.right
            self.right.next = self.next.left unless self.next.nil?
        end

        self.left.fix_next unless self.left.nil?
        self.right.fix_next unless self.left.nil?
    end

    def fix_next2
        if self.left
            self.left.next = self.right.nil? ? self.get_next : self.right
        end

        if self.right
            self.right.next = self.get_next
        end

        self.left.fix_next2 unless self.left.nil?
        self.right.fix_next2 unless self.left.nil?
    end

    def get_next
        it = self.next
        while it
            return it.left if it.left
            return it.right if it.right
            it = it.next
        end
        
        return nil
    end
end

root = Node::fill(1, 10)
root.fix_next2
root.inorder

puts

queue = [root]
next_count = 0
current_count = 1
while queue.any?
    current = queue.pop
    print "#{current.value} - #{current.next.nil? ? nil : current.next.value} "
    current_count -= 1
    length = queue.length
    queue.unshift(current.left) if current.left
    queue.unshift(current.right) if current.right
    next_count += queue.length - length
    if current_count == 0
        puts
        current_count = next_count
        next_count = 0
    end
end

