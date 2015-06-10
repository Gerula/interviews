# Given a binary tree, return the zigzag level order traversal of its nodes' values. (ie, from left to right, then right to left for the next level and alternate between).
#
# For example:
# Given binary tree {3,9,20,#,#,15,7},
#
#     3
#    / \
#   9  20
#     /  \
#    15   7
#
#    return its zigzag level order traversal as:
#
#          [
#           [3],
#           [20,9],
#           [15,7]
#          ]
#

class Node < Struct.new(:value, :left, :right)
end

root = Node.new(3,
                Node.new(20,
                         Node.new(7,
                                  nil,
                                  nil),
                         Node.new(15,
                                  nil,
                                  nil)),
                Node.new(9,
                         nil,
                         nil))

current_level = 1
next_level = 0
queue = [root]
left = true

while queue.any?
    current = queue.shift
    print "#{current.value} "
    current_level -= 1
    pre = queue.size
    if left
        queue.push(current.left) unless current.left.nil?
        queue.push(current.right) unless current.right.nil?
    else
        queue.push(current.right) unless current.right.nil?
        queue.push(current.left) unless current.left.nil?
    end

    next_level += queue.size + pre
    if current_level == 0
        puts
        current_level = next_level
        next_level = 0
        left = !left
    end
end

puts
