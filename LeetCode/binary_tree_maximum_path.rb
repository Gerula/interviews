class Node < Struct.new(:value, :left, :right)
    attr_accessor :max_sum
    
    def max
        @max_sum = 0  
        max_rec(self)
        @max_sum
    end

    def max_rec(current)
        return 0 if current.nil?

        left_sum = max_rec(current.left) 
        right_sum = max_rec(current.right)
        @max_sum = [left_sum + right_sum + current.value, @max_sum].max
        return [left_sum, right_sum].max + current.value
    end
end

root = Node.new(5,
                Node.new(6,
                         Node.new(3, nil, nil),
                         Node.new(4, nil, nil)),
                Node.new(1,
                         Node.new(10, nil, nil),
                         Node.new(1, nil, nil)))

queue = [root]
next_level = 0
current_level = 1
while queue.any?
    current = queue.shift
    print "#{current.value} "
    length = queue.size
    current_level -= 1
    queue.push current.left if current.left
    queue.push current.right if current.right
    next_level += queue.size - length
    if current_level == 0
        current_level = next_level
        next_level = 0
        puts
    end
end

puts root.max
