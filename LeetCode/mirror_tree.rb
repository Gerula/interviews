class Node < Struct.new(:value, :left, :right)
end

root = Node.new(1,
                Node.new(2,
                         Node.new(3),
                         Node.new(4)),
                Node.new(5,
                         Node.new(6),
                         Node.new(7)))

def inorder(root)
    stack = []
    current = root
    while current || stack.any?
        if current
            stack.push(current)
            current = current.left
        else
            current = stack.pop
            print "#{current.value} "
            current = current.right
        end
    end

    puts
end

def mirror(node)
    return nil if node.nil? 
    node.left, node.right = mirror(node.right), mirror(node.left)
    return node
end

inorder(root)
mirror(root)
inorder(root)
