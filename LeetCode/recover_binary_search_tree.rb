#  Two elements of a binary search tree (BST) are swapped by mistake.
#
#  Recover the tree without changing its structure. 
#

class Node < Struct.new(:value, :left, :right)
end

class Tree
    attr_reader :root

    def initialize
        @root = Tree.generate(0, Random.rand(15))
    end

    def self.generate(left, right)
        return nil if left > right
        mid = left + (right - left) / 2
        return Node.new(mid,
                        self.generate(left, mid - 1),
                        self.generate(mid + 1, right))
    end
    
    def swap_random
        one = nil
        while one.nil?
            one = get_random_node
        end

        two = nil
        while two.nil? || two.value == one.value
            two = get_random_node
        end

        puts "#{one.value} <-> #{two.value}"
        one.value, two.value = two.value, one.value
    end

    def get_random_node
        it = @root
        Random.rand(1..5).times {
            it = Random.rand(0..1) == 0 ? it.left : it.right unless it == nil
        }

        return it
    end

    private :get_random_node
end

def inorder(root)
    unless root.nil?
        inorder(root.left)
        puts(root.value)
        inorder(root.right)
    end
end

tree = Tree.new
inorder(tree.root)
tree.swap_random
inorder(tree.root)
