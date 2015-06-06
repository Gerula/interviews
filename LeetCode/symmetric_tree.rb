# Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).
#

class Node < Struct.new(:value, :left, :right)
end

class Tree
    attr_accessor :root

    def initialize
        @root = nil
    end

    def print_levels
        queue = [@root]
        current_level = 1
        next_level = 0
        while queue.any?
            current_level -= 1
            node = queue.shift
            print "#{node.value} "
            before = queue.size
            queue.push(node.left) unless node.left.nil?
            queue.push(node.right) unless node.right.nil?
            next_level += queue.size - before
            if current_level == 0
                puts
                current_level = next_level
                next_level = 0
            end
        end
    end
end

tree = Tree.new
tree.root = Node.new(1, 
                     Node.new(2, 
                              Node.new(3),
                              Node.new(4)),
                     Node.new(2, 
                              Node.new(4),
                              Node.new(3)))

tree.print_levels
