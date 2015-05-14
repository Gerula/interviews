#  Write an algorithm to find the ‘next’ node (i.e., in-order successor) of a given node in a binary search tree where each node has a link to its parent.

# Region: yak shaving

class Node < Struct.new(:value,:left,:right,:up)
end

def buildTree(array, left, right, up)
    if (left > right)
        return nil
    end

    middle = left + (right - left) / 2   
    if (left == right)
        return Node.new(array[middle], nil, nil, up)
    else
        current_up = Node.new(array[middle], nil, nil, up)
        left = buildTree(array, left, middle - 1, current_up)
        right = buildTree(array, middle + 1, right, current_up)
        current_up.left = left
        current_up.right = right
        return current_up
    end
end

current = buildTree(Array(1..30), 0, 30, nil)

def inorder_with_up(root)
    unless root == nil
        inorder_with_up(root.left)
        print "#{root.value} "
        if root.up
            puts "uppy #{root.up.value}"
        else
            puts "no uppy"
        end

        inorder_with_up(root.right)
    end
end

# EndRegion

def lca_leet_style(first, second)

end

inorder_with_up(current)

first = current.left.left.left.left
lca = current.left.left
second = current.left.left.right.right

puts "#{first.value} - #{lca.value} - #{second.value}"

first_breadcrumbs = []
second_breadcrumbs = []

def get_breadcrumbs(current)
    result = []
    while current
        result.push(current.value)
        current = current.up
    end

    result
end

first_breadcrumbs = get_breadcrumbs(first)
second_breadcrumbs = get_breadcrumbs(second)

puts first_breadcrumbs.inspect
puts second_breadcrumbs.inspect

first_iterator = first_breadcrumbs.length - 1
second_iterator = second_breadcrumbs.length - 1

while first_iterator > 0 && second_iterator > 0 && first_breadcrumbs[first_iterator] == second_breadcrumbs[second_iterator]
    first_iterator -= 1
    second_iterator -= 1
end

puts first_breadcrumbs[second_iterator + 1]
