# Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).
#
#  Bonus points if you could solve it both recursively and iteratively. 

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

    def inorder(root, result)
        unless root.nil?
            inorder(root.left, result)
            result << root.value
            inorder(root.right, result)
        end
    end

    def inorder_2(root, result)
        return if root.nil?
        inorder_2(root.right, result)
        result << root.value
        inorder_2(root.left, result)
    end

    def mirror?
        first = [@root]
        second = [@root]
        while first.any? && second.any?
            stan = first.shift
            bran = second.shift
            return false if stan.value != bran.value
            first.push(stan.left) unless stan.left.nil?
            first.push(stan.right) unless stan.right.nil?
            second.push(bran.right) unless bran.right.nil?
            second.push(bran.left) unless bran.left.nil?
        end
        return first == second
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
first = []
tree.inorder(tree.root, first)
second = []
tree.inorder_2(tree.root, second)
puts first.inspect + " - " + second.inspect
puts first == second
puts "Mirror 2"
puts tree.mirror?
