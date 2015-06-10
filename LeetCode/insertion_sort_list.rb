# Sort a linked list using insertion sort.
#

class Node < Struct.new(:value, :link)
end

class List
    def initialize
        @head = nil
    end

    def add(value)
        @head = Node.new(value, @head)
    end

    def sort
        new_head = Node.new(@head.value, nil)
        it = @head.link
        prev = @head
        while it
            if it.value < new_head.value
                new_head = Node.new(it.value, new_head)
            else
                prev = new_head
                new_it = new_head.link
                while new_it && new_it.value < it.value
                    prev = new_it
                    new_it = new_it.link 
                end
                prev.link = Node.new(it.value, prev.link)
            end
            it = it.link
        end
        @head = new_head
    end

    def display
        it = @head
        while it
            print "#{it.value} "
            it = it.link
        end
        puts
    end
end

list = List.new
10.times {
    list.add(Random.rand(1..100))
}

list.display
list.sort
list.display
