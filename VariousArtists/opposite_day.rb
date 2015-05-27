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

def tsil_bonus(root)
    it = root
    new_node = nil
    while !it.nil?
        new_node = Node.new(it.value, new_node)
        it = it.linky
    end
    new_node
end

puts_list(root)
puts_list(tsil_bonus(root))
puts_list(root)
root = tsil(root)
puts_list(root)
