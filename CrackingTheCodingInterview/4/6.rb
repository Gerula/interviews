#  Design an algorithm and write code to find the first common ancestor of two nodes in a binary tree. Avoid storing additional nodes in a data structure. NOTE: This is not necessarily a binary search tree.
#

class Node < Struct.new(:value, :left, :right)
    def inorder
        do_inorder(self)
    end

    def do_inorder(root)
        return if root.nil?
        do_inorder(root.left)
        puts root.value
        do_inorder(root.right)
    end

    def lca(first, second)
        return bst_lca(first, second) if is_bst?
    end

    def bst_lca(first, second)
        current = self
        while !current.nil?
            return current if current.value.between?(first, second)
            current = current.left if current.value > second
            current = current.right if current.value < second
        end    
        return current
    end

    def is_bst?
        do_check_bst(self, 0, 100) 
    end

    def do_check_bst(root, min, max)
        return root.nil? ||
               root.value.nil? ||
               root.value.between?(min, max) &&
               do_check_bst(root.left, 0, root.value) &&
               do_check_bst(root.right, root.value, 100)
    end

    private :do_inorder
    private :bst_lca
    private :is_bst?
    private :do_check_bst
end

def fill(array, left, right)
    return if left > right

    middle = left + (right - left) / 2
    return Node.new(array[middle],
                    fill(array, left, middle - 1),
                    fill(array, middle + 1, right))
end

root = fill([1, 2, 3, 4, 5, 6, 7, 8, 9], 0, 9)
puts root.lca(2, 8).value
