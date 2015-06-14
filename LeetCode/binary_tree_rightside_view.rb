# Given a binary tree, imagine yourself standing on the right side of it, return the values of the nodes you can see ordered from top to bottom.
#
# For example:
# Given the following binary tree,
#
#       1            <---
#     /   \
#    2     3         <---
#     \     \
#      5     4       <---
#
#        You should return [1, 3, 4]. 
#
#   This is what really grinds my gears with these fuckers. It was probably to hard to write this test case right here. This is what the problem actually is.
#
#       1            <---
#     /   \
#    2     3         <---
#     \     \
#      5     4       <---
#     /
#    6
#
#     You should return [1, 3, 4, 6]. 
#

class Node < Struct.new(:value, :left, :right)
end

class Tree
    attr_accessor :root

    def initialize
        @root = nil
    end

    def rightside
        queue = [@root]
        next_level = 0
        current_level = 1
        while queue.any?
            current = queue.shift
            current_level -= 1
            size = queue.size
            queue.push(current.left) unless current.left.nil?
            queue.push(current.right) unless current.right.nil?
            next_level += queue.size - size
            if current_level == 0
                print "#{current.value} "
                current_level = next_level
                next_level = 0
            end
        end
    end

    def inorder
        stack = []
        current = @root
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
    end
end

tree = Tree.new
tree.root = Node.new(1,
                     Node.new(2,
                              nil,
                              Node.new(5,
                                       Node.new(6, nil, nil),
                                       nil)),
                    Node.new(3,
                             nil,
                             Node.new(4,
                                      nil,
                                      nil)))
tree.inorder
puts tree.rightside
