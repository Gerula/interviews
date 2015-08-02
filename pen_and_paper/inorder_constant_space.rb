class Node < Struct.new(:value, :left, :right, :parent)
    def inorder
        current = self
        stack = []
        result = []
        while current || stack.any?
            if current 
                stack.push(current)
                current = current.left
            else
                current = stack.pop
                result << current
                current = current.right
            end
        end

        return result.map { |x| "[val: #{x.value} - #{x.parent ? x.parent.value : nil}] " }.join
    end

    def const_inorder
        result = []
        prev = nil
        current = self
        next_curr = nil
        while current
            if current.parent == prev
                if current.left
                    next_curr = current.left
                else
                    result << current
                    next_curr = current.right.nil? ? current.parent : current.right
                end
            elsif current.left == prev
                result << current
                next_curr = current.right.nil? ? current.parent : current.right
            else
                next_curr = current.parent
            end
            
            prev = current
            current = next_curr
        end

        return result.map { |x| "[val: #{x.value} - #{x.parent ? x.parent.value : nil}] " }.join
    end
end

def fill(low, high)
    return nil if low > high
    mid = low + (high - low) / 2
    new_node = Node.new(mid,
                        fill(low, mid - 1),
                        fill(mid + 1, high))
    new_node.left.parent = new_node if new_node.left
    new_node.right.parent = new_node if new_node.right
    return new_node
end

node = fill(1, 10)
puts node.inorder
puts node.const_inorder
