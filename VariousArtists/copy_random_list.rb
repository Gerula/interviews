# So let's say you have a linked list with link to next and to a random node within the list. Copy the list.

class ListNode < Struct.new(:value, :next, :jump)
end

class List
    include Enumerable

    def initialize
        @head = nil
        @count = 0
    end

    def <<(node)
        @count += 1
        node.next = @head
        @head = node
    end

    def [](index)
        it = @head
        while index > 0 && !it.nil?
            index -= 1
            it = it.next
        end

        it
    end

    def printout
        it = @head
        while !it.nil?
            print "#{it.value} - "
            print "#{it.next.value} - " unless it.next.nil?
            print "#{it.jump.value} - " unless it.jump.nil?
            it = it .next
            puts
        end
    end   

    def jump
        it = @head
        while !it.nil?
            rand_jump = Random.rand(@count - 1)
            it.jump = self[rand_jump]
            it = it.next
        end
    end   
end

list = List.new
list << ListNode.new(1)
list << ListNode.new(2)
list << ListNode.new(3)
list << ListNode.new(4)
list << ListNode.new(5)
list << ListNode.new(6)
list.jump
list.printout
