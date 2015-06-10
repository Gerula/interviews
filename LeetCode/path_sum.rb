#  Given a binary tree and a sum, determine if the tree has a root-to-leaf path such that adding up all the values along the path equals the given sum.
#  For example:
#  Given the below binary tree and sum = 22,
#
#                5
#               / \
#              4   8
#             /   / \
#            11  13  4
#           /  \      \
#          7    2      1
#
#  Return true, as there exist a root-to-leaf path 5->4->11->2 which sum is 22.
#

class Node < Struct.new(:value, :left, :right)
end

root = Node.new(5,
                Node.new(4,
                         Node.new(11,
                                  Node.new(7,
                                           nil,
                                           nil),
                                  Node.new(2,
                                           nil,
                                           nil)),
                        nil),
                Node.new(8,
                         Node.new(13,
                                  nil,
                                  nil),
                         Node.new(4,
                                  nil,
                                  Node.new(1,
                                           nil,
                                           nil))))

stack = []
current = root
while stack.any? || current
    if current.nil?
        current = stack.pop
        print "#{current.value} "
        current = current.right
    else
        stack.push(current)
        current = current.left
    end
end

puts

def path_sum(node, sum, target)
    return false if node.nil?
    if node.left.nil? && node.right.nil? 
        return sum + node.value == target
    end

    return path_sum(node.left, sum + node.value, target) || path_sum(node.right, sum + node.value, target) 
end

puts path_sum(root, 0, 30)
puts path_sum(root, 0, 22)
puts path_sum(root, 0, 26)


