#  Given a sorted linked list, delete all duplicates such that each element appear only once. 
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

    def dedup
        it = @root
        prev = nil
        while it
            if prev && it.value == prev.value
                prev.link = it.link
            else
                prev = it
            end
            it = it.link
        end
    end
end

list = List.new
list.add(1)
list.add(1)
list.add(2)
list.add(2)
list.add(2)
list.add(2)
list.add(3)
list.add(4)
list.add(4)
list.add(4)
list.add(4)
list.display
list.dedup
list.display
