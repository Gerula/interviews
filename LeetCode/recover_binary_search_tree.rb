#  Two elements of a binary search tree (BST) are swapped by mistake.
#
#  Recover the tree without changing its structure. 
#

class Node < Struct.new(:value, :left, :right)
end

class Tree
    attr_reader :root

    def initialize
        @root = Tree.generate(1, Random.rand(15))
        @first = nil
        @second = nil
        @prev = nil
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

    def unswap_random
        find_swap(@root)
        @first.value, @second.value = @second.value, @first.value
    end
    
    def get_random_node
        it = @root
        Random.rand(1..5).times {
            it = Random.rand(0..1) == 0 ? it.left : it.right unless it == nil
        }

        return it
    end

    def to_s
        inorder(@root)
    end

    def inorder(root)
        unless root.nil?
            inorder(root.left)
            print "#{root.value} "
            inorder(root.right)
        end
    end

    def find_swap(root)
        unless root.nil?
            find_swap(root.left)
            if !@prev.nil? && root.value < @prev.value
                if @first.nil?
                    @first = @prev
                else
                    @second = root
                end
            end
            @prev = root
            find_swap(root.right)
        end
    end

    private :find_swap
    private :inorder
    private :get_random_node
end

$first = nil
$second = nil

tree = Tree.new
puts tree.to_s
tree.swap_random
puts tree.to_s
tree.unswap_random
puts tree.to_s
