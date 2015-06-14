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
puts tree.root
