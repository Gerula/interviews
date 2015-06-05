# Reverse k group
#
# Given this linked list: 1->2->3->4->5
#
# For k = 2, you should return: 2->1->4->3->5
#
# For k = 3, you should return: 3->2->1->4->5 
#

class Node < Struct.new(:value, :link)
end

class List
    def initialize
        @root = nil
    end

    def add(value)
        @root = Node.new(value, @root)
    end

    def display
        it = @root
        while it
            print "#{it.value} "
            it = it.link
        end
        puts
    end

    def reverse(k)
        node = @root
        node = node.link.link
        node.link = reverse_int(node, node.link, k)
    end

    def reverse_int(prev, start, k)
        while start && k > 0
            link = start.link
            start.link = prev
            prev = start
            start = link
        end
        return start
    end
end

list = List.new
(1..10).reverse_each { |i|
    list.add(i)
}

list.display
list.reverse(2)
list.display
