# Write an algorithm to find the ‘next’ node (i.e., in-order successor) of a given node in a binary search tree where each node has a link to its parent. 
 
class TreeNode < Struct.new(:value, :left, :right, :up)
end
 
def inorder(root)
    unless root == nil
        inorder(root.left)
        next_node = get_next_in_inorder(root)
        if next_node.nil?
            puts "#{root.value} next none"
        else
            puts "#{root.value} next #{get_next_in_inorder(root).value}"
        end
        inorder(root.right)
    end
end
 
def get_next_in_inorder(root)
    return root.up unless root.up.nil? || root.up.left != root
     
    if !root.right.nil?
        root = root.right
        while !root.left.nil?
           root = root.left
        end
         
        return root
    end
     
    while !root.up.nil? && root.up.right == root
        root = root.up
    end
     
    return root.up
end
 
def fill_with_sorted_data(array, left, right, up)
    if (left > right)
        return nil
    end
     
    middle = left + (right - left) / 2
    newNode = TreeNode.new(array[middle], nil, nil, up)
    if (left != right)
        newNode.left = fill_with_sorted_data(array, left, middle -1, newNode)
        newNode.right = fill_with_sorted_data(array, middle + 1, right, newNode)
    end
    return newNode
end
 
tree = fill_with_sorted_data([1, 2, 3, 4, 5, 6, 7, 8], 0, 8, nil)
inorder(tree)
