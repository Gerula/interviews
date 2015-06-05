# Given a singly linked list where elements are sorted in ascending order, convert it to a height balanced BST.
#

class Node < Struct.new(:value, :link)
    def to_s
        "#{value} "
    end
end

class TreeNode < Struct.new(:value, :left, :right)
end

class Tree
    def initialize
        @root = nil
    end

    def from_list(list)
        @root = from_list_rec(list, 0, list.len - 1)
    end    

    def from_list_rec(list, l, r)
        return nil if l>r
        m = l + (r - l) / 2
        return TreeNode.new(list[m],
                        from_list_rec(list, l, m - 1),
                        from_list_rec(list, m + 1, r))
    end

    def to_s
        it = @root
        stack = []
        result = "Tree: "
        while it || stack.any?
            if it.nil?
                it = stack.pop
                result << "#{it.value} "
                it = it.right
            else
                stack.push(it)
                it = it.left
            end
        end
        
        return result
    end
end

class List
    attr_accessor :len

    def initialize
        @root = nil
        @len = 0
    end

    def add(value)
        @root = Node.new(value, @root)
        @len += 1
    end

    def [](value)
        return nil if value >= @len
        it = @root
        while value > 0
            it = it.link
            value -= 1 
        end

        return it.value
    end

    def to_s
        it = @root
        s = ""
        while it
             s << it.to_s
             it = it.link
        end
        
        return s
    end
end

list = List.new
(1..10).reverse_each {|i|
    list.add(i)
}

tree = Tree.new
tree.from_list(list)
puts tree.to_s
