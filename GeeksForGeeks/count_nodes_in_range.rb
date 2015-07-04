class Node < Struct.new(:value, :left, :right)
end

root = Node.new(10,
                Node.new(5,
                         Node.new(1)),
                Node.new(50,
                         Node.new(40),
                         Node.new(100)))

def count(node, low, high)
    return 0 if node.nil?
    left = count(node.left, low, high)
    right = count(node.right, low, high)
    current = node.value.between?(low, high) && 
              (left == 1 || node.left.nil?) && 
              (right == 1 || node.right.nil?) ? 1 : 0

    return current + left + right
end

puts count(root, 1, 45)
