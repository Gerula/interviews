# I had a sociopath once asked me this in an interview. Of course I fucked it up.
# It goes like this. Make a function to return the n_th node from a binary search tree.
#

class Node < Struct.new(:value, :left, :right)
end

def inorder root
    unless root.nil?
        inorder root.left
        puts root.value
        inorder root.right
    end
end

def fill array, l, r
    if l > r
        return nil
    end

    middle = l + (r - l) / 2
    newNode = Node.new array[middle], nil, nil
    
    unless l == r
        newNode.left = fill array, l, middle - 1
        newNode.right = fill array, middle + 1, r
    end

    return newNode
end

def n_th root, index
    current = root
    stack = []
    i = 0
    while stack.any? || current
        if current
            stack.push current
            current = current.left
        else
            current = stack.pop
            i += 1
            if index == i
                return current
            end
            current = current.right
        end
    end

    return null
end

tree = fill [1, 2, 3, 4, 5, 6, 7, 8], 0, 8
#inorder tree
puts n_th(tree, 2).value
