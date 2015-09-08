class Node < Struct.new(:value, :left, :right, :center)
end

root = Node.new(1)
queue = [root]
index = 1
while index < 30
    current = queue.shift
    current.left = Node.new(index + 1)
    current.center = Node.new(index + 2)
    current.right = Node.new(index + 3)
    index += 3
    queue.push([current.left, current.right, current.center]).flatten!
end

queue = [root]
next_level = 0
current_level = 1
while queue.any?
    current_level -= 1
    current = queue.shift
    print "#{current.value} "
    size = queue.size
    queue.push(current.left) unless current.left.nil?
    queue.push(current.center) unless current.center.nil?
    queue.push(current.right) unless current.right.nil?
    next_level += queue.size - size
    if current_level == 0
        current_level = next_level
        next_level = 0
        puts
    end
end

def traverse(left, right, bottom, parent, current)
    
end
