class Node < Struct.new(:value, :link)
end

root = nil
5.downto(1).each { |x|
    root = Node.new(x, root)
}

def display(root)
    while root
        print "#{root.value} "
        root = root.link
    end

    puts
end

def remove_k(root, k)
    first = root
    second = root
    (k + 1).times { 
        second = second.link
    }

    while second
        first = first.link
        second = second.link
    end

    first.link = first.link.link
end

display(root)
remove_k(root, 2)
display(root)
