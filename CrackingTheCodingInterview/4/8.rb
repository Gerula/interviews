# Design an algorithm to print all paths which sum up to that value. Note that it can be any path in the tree - it does not have to start at the root.
#

class Node < Struct.new(:value, :left, :right)
end

def fill(array, left, right)
    if left> right
        return nil
    end

    mid = left + (right - left) / 2
    return Node.new(array[mid],
                    fill(array, left, mid - 1),
                    fill(array, mid + 1, right))
end

def inorder(tree)
    if !tree
        return
    end

    inorder(tree.left)
    puts tree.value
    inorder(tree.right)
end

def paths_from_root(root, sum, currentList, level)
    if root.nil?
        return
    end
    
    tmp = sum
    currentList.push(root)

    level.downto(0).each { |i|
        unless currentList[i].nil? || currentList[i].value.nil?
            tmp -= currentList[i].value
            if tmp == 0
                i.upto(level).each { |j|
                print "#{currentList[j].value} "
                }
                puts
            end
        end
        }
    leftList = currentList.clone
    rightList = currentList.clone

    paths_from_root(root.left, sum, leftList, level + 1)
    paths_from_root(root.right, sum, rightList, level + 1)
end

tree = fill([1, 2, 3, 4, 5, 6, 7, 8], 0, 8)
#inorder(tree)
paths_from_root(tree, 5, [], 0)
