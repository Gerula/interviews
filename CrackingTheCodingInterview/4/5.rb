#  Write an algorithm to find the ‘next’ node (i.e., in-order successor) of a given node in a binary search tree where each node has a link to its parent.
#
#  I WILL DO IT WITHOUT LINK TO PARENT WITH MY MAJESTIC MIND


# Region: yak shaving

class Node < Struct.new(:value,:left,:right)
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

current = buildTree([1, 2, 3, 4, 5, 6, 7, 8, 9], 0, 9)

# EndRegion

def lca_leet_style(first, second)

end
