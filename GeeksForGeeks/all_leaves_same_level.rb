class Node < Struct.new(:value, :left, :right)
end

root = Node.new(10,
                Node.new(5,
                         Node.new(1)),
                Node.new(50,
                         Node.new(40),
                         Node.new(100,
                                  Node.new(1))))


def leaves_same_level?(root, level, current_level)
    left = root.left ? leaves_same_level?(root.left, level, current_level + 1) : true
    right = root.right ? leaves_same_level?(root.right, level, current_level + 1) : true

    if root.left.nil? && root.right.nil?
        if level[0] == -1
            level[0] = current_level
            return true
        else
            return level[0] == current_level
        end
    end

    return left && right
end

puts leaves_same_level?(root, [-1], 1)
