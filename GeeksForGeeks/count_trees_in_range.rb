class Node < Struct.new(:value, :left, :right)
end

root = Node.new(10,
                Node.new(5,
                         Node.new(1)),
                Node.new(50,
                         Node.new(40),
                         Node.new(100)))

def count(node, low, high, cunt)
    return true if node.nil?
    left = count(node.left, low, high, cunt)
    right = count(node.right, low, high, cunt)

    if left && right && node.value.between?(low, high)
        cunt[0] += 1
        return true
    end

    return false
end

cunt = [0]
count(root, 1, 45, cunt)
puts cunt.inspect
