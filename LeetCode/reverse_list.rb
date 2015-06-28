class Node < Struct.new(:value, :link)
    def display
        it = self
        while it
            print "#{it.value} "
            it = it.link
        end

        puts
    end
end

head = nil
1.upto(10).each { |x|
    head = Node.new(x, head)
}

prev = nil
it = head
while it
    link = it.link
    it.link = prev
    prev = it
    it = link
end

head = prev

def reverse(list)
    return list if list.nil? || list.link.nil?
    reverse_node = reverse(list.link)
    list.link.link = list
    list.link = nil
    return reverse_node
end

head.display
head = reverse(head)
head.display
