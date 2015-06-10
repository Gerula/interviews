# Given a binary tree, return the bottom-up level order traversal of its nodes' values. (ie, from left to right, level by level from leaf to root).
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
#    return its bottom-up level order traversal as:
#
#             [
#               [15,7],
#               [9,20],
#               [3]
#             ]
#

class Node < Struct.new(:value, :left, :right, :level)
end

root = Node.new(3,
                Node.new(9,
                         nil,
                         nil),
                Node.new(20,
                         Node.new(15,
                                  nil,
                                  nil),
                         Node.new(7,
                                  nil,
                                  nil)))

result = {}
root.level = 0
queue = [root]
while queue.any?
    current = queue.shift
    level = current.level
    result[level] ||= []
    result[level] << current
    unless current.left.nil?
       current.left.level = level + 1
       queue.push(current.left)
    end
    unless current.right.nil?
       current.right.level = level + 1
       queue.push(current.right)
    end
end

result.keys.reverse.each { |x|
    puts result[x].map { |x| x.value }.inspect
}

