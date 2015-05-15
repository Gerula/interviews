# I had a sociopath once asked me this in an interview. Of course I fucked it up.
# It goes like this. Make a function to return the n_th node from a binary search tree.
#

class Node < Struct.new(:value, :left, :right, :countleft, :countright)
end

def inorder root
    unless root.nil?
        inorder root.left
        puts "val #{root.value} c #{root.countleft} #{root.countright}"
        inorder root.right
    end
end

def find_n_th root, n
    while root
        if root.countleft + 1 == n
            return root
        end

        if root.countleft < n
            root = root.right
            n = n - root.countleft + 1
        else
            root = root.left
        end
    end
end

def fill array, l, r
    if l > r
        return nil
    end

    middle = l + (r - l) / 2
    newNode = Node.new array[middle], nil, nil, 0, 0
    
    unless l == r
        newNode.left = fill array, l, middle - 1
        newNode.right = fill array, middle + 1, r
        
        if newNode.left
            newNode.countleft += 1
            newNode.countleft += newNode.left.countleft + newNode.left.countright
        end

        if newNode.right
            newNode.countright += 1
            newNode.countright += newNode.right.countleft + newNode.right.countright
        end
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
puts find_n_th(tree, 2).value
