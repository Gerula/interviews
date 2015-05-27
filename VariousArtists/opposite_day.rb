# tsil
#

class Node < Struct.new(:value, :linky)
end

root = nil
1.upto(10).each{ |i|
    root = Node.new(i, root)
}

def puts_list(root)
    while !root.nil?
        print "#{root.value} "
        root = root.linky
    end
    
    puts
end

def tsil(root)
    it = root
    prev = nil
    while !it.nil?
        next_node = it.linky
        it.linky = prev
        prev = it
        it = next_node
    end

    return prev
end

puts_list(root)
root = tsil(root)
puts_list(root)

