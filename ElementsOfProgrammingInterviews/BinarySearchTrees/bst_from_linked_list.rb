# These fuckers tricked us. They say to reuse the list. But you can't reuse the list, you NEED to reallocate memory.
# What a sham!
#

class Node < Struct.new(:value, :left, :right)
    def length
        it = self
        count = 0
        while it
            count += 1
            it = it.right
        end

        return count
    end
end

root = nil
10.downto(1).each { |i|
    root = Node.new(i, nil, root)
}

def print_level(root)
    queue = [root]
    current_level = 1
    next_level = 0
    while queue.any?
        current = queue.shift
        print "#{current.value} "
        current_level -= 1
        len = queue.size
        queue << current.left unless current.left.nil?
        queue << current.right unless current.right.nil?
        next_level += queue.size - len
        if current_level == 0
            puts
            current_level = next_level
            next_level = 0
        end
    end
end

print_level(root)
puts "Tree"

def get_tree(list, left, right) 
    return nil if left > right
    mid = left + (right - left) / 2
    it = list
    (mid - left).times { it = it.right }
    return nil if it.nil?
    it.left = get_tree(list, left, mid - 1)
    it.right = get_tree(it.right, mid + 1, right)
    return it
end

def inorder(root)
    unless root.nil?
        inorder(root.left)
        print "#{root.value} "
        inorder(root.right)
    end
end

puts "built O(N log N)"
treeRoot = get_tree(root, 0, root.length)
print_level(treeRoot)
puts "inorder"
inorder(treeRoot)
puts

def get_tree_in(list, left, right)
    return nil if left >= right
    mid = left + (right - left ) / 2
    node = Node.new
    node.left = get_tree_in(list, left, mid - 1)
    node.value = list.first.value
    list[0] = list.first.right
    node.right = get_tree_in(list, mid + 1, right) 
    return node
end

root = nil
10.downto(1).each { |i|
    root = Node.new(i, nil, root)
}

puts "built O(N)"
treeRoot2 = get_tree_in([root], 0, root.length) 
print_level(treeRoot2)
puts "inorder"
inorder(treeRoot2)
puts
