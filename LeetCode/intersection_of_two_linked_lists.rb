class Node < Struct.new(:value, :link)
end

first = nil
10.downto(1).each { |x|
    first = Node.new(x, first)
}

it = first
Random.rand(2..10).times {
    it = it.link
}

second = nil
4.downto(1).each { |x|
    second = Node.new(x, second)
}

second_it = second
while second_it.link
    second_it = second_it.link
end

second_it.link = it

def display(node)
    while node
        print "#{node.value} "
        node = node.link
    end

    puts
end

def length(node)
    length = 0
    while node
        length += 1
        node = node.link
    end
    
    return length
end

display(first)
display(second)
first_len = length(first)
second_len = length(second)
if first_len > second_len
    (first_len - second_len).times {
        first = first.link
    }
else
    (second_len - first_len).times {
        second = second.link
    }
end

while first != second
    first = first.link
    second = second.link
end

puts first
