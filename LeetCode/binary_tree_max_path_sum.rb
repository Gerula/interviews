#  Given a binary tree, find the maximum path sum.
#
#  The path may start and end at any node in the tree. 
#

class Node < Struct.new(:value, :left, :right)
end

root = Node.new(1,
                Node.new(2, nil, nil),
                Node.new(3, nil, nil))

def max_sum(root, max) 
    return 0 if root.nil?
    left = max_sum(root.left, max)
    right = max_sum(root.right, max)
    max_sum = [root.value, left, left + root.value, right + root.value, left + right + root.value].max
    max_top = [root.value, left + root.value, right + root.value].max
    max[0] = max_sum
    return max_top
end

max = []
max_sum(root, max)
puts max.inspect

