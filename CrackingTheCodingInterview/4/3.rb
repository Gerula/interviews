#  Given a sorted (increasing order) array, write an algorithm to create a binary tree with minimal height.
#

class Node < Struct.new(:value, :left, :right)
end

def inorder(current)
    unless current == nil
        inorder(current.left)
        puts current.value
        inorder(current.right)
    end
end

def buildTree(array, left, right)
    if (left > right)
        return nil
    end

    middle = left + (right - left) / 2   

    if (left == right)
        return Node.new(array[middle], nil, nil)
    else
        return Node.new(array[middle], 
                        buildTree(array, left, middle - 1), 
                        buildTree(array, middle + 1, right))
    end
end

current = Node.new(1, nil, nil)
current.left = Node.new(2, nil, nil)
current.right = Node.new(3, nil, nil)
inorder(current)
puts "----- separator -----"
current = buildTree([1, 2, 3, 4, 5, 6, 7, 8, 9], 0, 9)
inorder(current)

#  Given a binary search tree, design an algorithm which creates a linked list of all the nodes at each depth (i.e., if you have a tree with depth D, you’ll have D linked lists).

class ListNode < Struct.new(:value, :next)
end

levels = {}
level = 0 
queue = [current]
nodes_in_level = 1
nodes_in_next_level = 0

while queue.any?
    current = queue.pop
    new_node = ListNode.new(current, levels[level])
    levels[level] = new_node 
    nodes_in_level -= 1

    if (current.left)
        queue.unshift(current.left)
        nodes_in_next_level += 1
    end

    if (current.right)
        queue.unshift(current.right)
        nodes_in_next_level += 1
    end

    if nodes_in_level == 0
        level += 1
        nodes_in_level = nodes_in_next_level
        nodes_in_next_level = 0
    end
end

levels.each do |level, list|
    puts "Level #{level}"
    idx = list
    while idx
        print " #{idx.value.value}"
        idx = idx.next
    end

    puts
end

