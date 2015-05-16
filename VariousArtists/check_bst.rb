# check if a tree is a BST

class Node < Struct.new(:value, :left, :right)
    def inorder
        do_inorder(self)
    end

    def do_inorder(root)
        unless root.nil?
            do_inorder(root.left)
            puts root.value
            do_inorder(root.right)
        end
    end

    def is_bst?
        do_is_bst?(self, 0, 100)
    end

    def do_is_bst?(root, min, max)
        if root.nil? || root.value.nil?
            return true
        end

        return root.value.between?(min, max) && 
               do_is_bst?(root.left, min, root.value) &&
               do_is_bst?(root.right, root.value, max)
    end
end

def fill(a, l, r)
    unless l > r
        m = l + (r - l) / 2
        return Node.new(a[m],
                        fill(a, l, m - 1),
                        fill(a, m + 1, r))
    end
end
    
root = fill([1, 2, 3, 4, 5], 0, 5)
root.inorder
puts root.is_bst?
root = Node.new(100, root, root)
root.inorder
puts root.is_bst?
