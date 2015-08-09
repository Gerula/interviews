class Node < Struct.new(:value, :left, :right)
end

def gen(low, high)
    return nil if low > high
    mid = low + (high - low) / 2
    return Node.new(mid, gen(low, mid - 1), gen(mid + 1, high))
end

def levels(result, level, node)
    return if node.nil?
    result[level] ||= []
    if level % 2 == 0
        result[level].push(node.value)
    else
        result[level].unshift(node.value)
    end

    levels(result, level + 1, node.left)
    levels(result, level + 1, node.right)
end

result = []
levels(result, 0, gen(1, 20))
result.each { |x|
    puts x.inspect
}
