class Node < Struct.new(:value, :left, :right)
    def to_s
        return "#{value} #{left ? left.to_s : "nil"} #{right ? right.to_s : "nil"}"
    end
end

def construct(a)
    stack = []
    a.reverse.each { |x|
        if x.nil?
            stack.push(x)
        else
            stack.push(Node.new(x, stack.pop, stack.pop))
        end
    }

    return stack.first
end

node = construct([1, 2, 3, nil, 4, nil, nil, nil, nil])
puts node
