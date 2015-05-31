#  The nodes in a standard binary tree contain a next pointer that points to NULL. Change the next pointer to point to the nearest node to the right and on the same level. 
#

class Node < Struct.new(:val, :left, :right, :next)
end

class Tree
    def initialize
        @root = fill(1, 10)
    end

    def fill(l, r)
        return nil if l > r
        m = l + (r - l) / 2
        return Node.new(m,
                        fill(l, m - 1),
                        fill(m + 1, r))
    end

    def inorder(block)
        stack = []
        current = @root
        while stack.any? || current
            if current.nil?
                current = stack.pop
                block.call(current)
                current = current.right
            else
                stack.push(current)
                current = current.left
            end
        end
    end

    def bfs_levels
        queue = [@root]
        level = 1
        levels = 0
        print "Level: #{levels} "
        next_level = 0
        prev = nil
        while queue.any?
            current = queue.pop
            prev.next = current unless prev.nil? 
            prev = current

            print "[#{current.val}]"
            level -= 1
            count = queue.size
            queue.unshift(current.left) unless current.left.nil?
            queue.unshift(current.right) unless current.right.nil?
            next_level += queue.size - count

            if level == 0 && queue.any?
                levels += 1
                puts
                print "Level: #{levels} "
                level = next_level
                next_level = 0
                prev = nil
            end
        end
    end

    def connect
        slow = @root
        fast = @root
        while slow
            if slow.left
                fast.next = slow.left
                fast = fast.next
            end
            if slow.right
                fast.next = slow.right
                fast = fast.next
            end
            slow = slow.next
        end
    end

    def connect_rec(node)
        return if node.nil?
        if node.left
            node.left.next = node.right
        end
        if node.right
            node.right.next = node.next ? node.next.left : nil
        end

        connect_rec(node.left)
        connect_rec(node.right)
    end
end

tree = Tree.new
tree.inorder(->(x){print "#{x.val} "})
puts
tree.bfs_levels
puts
tree.inorder(->(x){
    print "[#{x.val} "
    print (x.next.nil? ? "x]" : "#{x.next.val}] ")
})
puts
tree2 = Tree.new
puts
tree2.inorder(->(x){
    print "[#{x.val} "
    print (x.next.nil? ? "x]" : "#{x.next.val}] ")
})
puts
tree2.connect
puts
tree2.inorder(->(x){
    print "[#{x.val} "
    print (x.next.nil? ? "x]" : "#{x.next.val}] ")
})
puts

