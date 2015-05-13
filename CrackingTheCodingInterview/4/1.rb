#  Implement a function to check if a tree is balanced. For the purposes of this question, a balanced tree is defined to be a tree such that no two leaf nodes differ in distance from the root by more than one.
#

class Tree
    def initialize(value = nil, left = nil, right = nil)
        @value = value
        @left = left
        @right = right
    end

    attr_accessor :value
    attr_accessor :left
    attr_accessor :right
end

def inorder(root)
    unless root == nil
        inorder(root.left)
        puts (root.value)
        inorder(root.right)
    end
end

def height(root)
    if !root
        return 0
    end

    return 1 + [height(root.left), height(root.right)].max
end

def balanced?(root)
    if !root
        return true
    end

    return (height(root.left) == height(root.right)) && balanced?(root.right) && balanced?(root.left)
end

root = Tree.new(0)
root.left = Tree.new(2)
root.right = Tree.new(3)
root.left.left = Tree.new(4)
root.left.right = Tree.new(5)
puts balanced?(root)
puts height(root)


root = Tree.new(0)
root.left = Tree.new(0)
root.right = Tree.new(0)
puts balanced?(root)
puts height(root)
