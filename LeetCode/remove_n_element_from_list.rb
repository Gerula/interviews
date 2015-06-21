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
    len = 0
    it = root
    while it
        len += 1
        it = it.link
    end
    it = root
    (len - k - 1).times {
        it = it.link
    }

    it.link = it.link.link
end

display(root)
remove_k(root, 2)
display(root)
