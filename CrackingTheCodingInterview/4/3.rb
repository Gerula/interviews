#  Given a sorted (increasing order) array, write an algorithm to create a binary tree with minimal height.
#

class Node < Struct.new(:value, :left, :right)
end

def inorder(root)
    unless root == nil
        inorder(root.left)
        puts root.value
        inorder(root.right)
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

root = Node.new(1, nil, nil)
root.left = Node.new(2, nil, nil)
root.right = Node.new(3, nil, nil)
inorder(root)
puts "----- separator -----"
root = buildTree([1, 2, 3, 4, 5, 6, 7, 8, 9], 0, 9)
inorder(root)
