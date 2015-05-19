# So let's say you have a linked list with link to next and to a random node within the list. Copy the list.

class ListNode < Struct.new(:value, :next, :jump)
end

class List
    attr_accessor :head

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
        puts "--- begin printout ---"
        it = @head
        while !it.nil?
            print "val:#{it.value} - "
            print "next:#{it.next.value} - " unless it.next.nil?
            print "jump:#{it.jump.value} - " unless it.jump.nil?
            it = it .next
            puts
        end
        puts "--- end printout ---"
    end   

    def jump
        it = @head
        while !it.nil?
            rand_jump = Random.rand(@count - 1)
            it.jump = self[rand_jump]
            it = it.next
        end
    end 

    def copy
        it = @head
        result = List.new
        while !it.nil?
            new_node = ListNode.new(it.value, it.next)
            it.next = new_node
            it = new_node.next
        end

        it = @head.next
        while !it.next.nil?
            it.jump = it.jump.next unless it.jump.nil?
            it = it.next
        end

        it = @head
        while !it.nil?
            it.next = it.next.next
            it = it.next
        end

        result.head = @head
        result
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
list.copy.printout
