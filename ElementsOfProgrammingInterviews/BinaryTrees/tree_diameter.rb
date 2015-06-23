class Node < Struct.new(:value, :left_cost, :left, :center_cost, :center, :right_cost, :right)
end

root = Node.new(:b,
                7,
                Node.new(:c,
                         4,
                         Node.new(:d,
                                  nil,
                                  nil,
                                  6,
                                  Node.new(:e)),
                         nil,
                         nil,
                         3,
                         Node.new(:x)),
                14,
                Node.new(:a),
                3,
                Node.new(:y,
                          2,
                          Node.new(:z)))

def diameter(node, sum, diameter)
    return 0 if node == nil
    
    left = node.left ? diameter(node.left, sum + node.left_cost, diameter) + node.left_cost : 0
    right = node.right ? diameter(node.right, sum + node.right_cost, diameter) + node.right_cost : 0 
    center = node.center ? diameter(node.center, sum + node.center_cost, diameter) + node.center_cost : 0
    max = [left, right, center].max
    diameter[0] = [left + right, center + right, center + left].max
    return max
end

diameter = []
diameter(root, 0, diameter)
puts diameter.inspect




