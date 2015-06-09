#  Reverse a linked list from position m to n. Do it in-place and in one-pass.
#
#  For example:
#  Given 1->2->3->4->5->NULL, m = 2 and n = 4,
#
#  return 1->4->3->2->5->NULL.
#
#  Note:
#  Given m, n satisfy the following condition:
#  1 ≤ m ≤ n ≤ length of list. 
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

    def display
        it = @head
        while it
            print "#{it.value} "
            it = it.link
        end
        puts
    end

    def reverse(left, right)
        prev = @head
        (left - 2).times {
            prev = prev.link
        }
        
        current = prev.link.link
        start = current
        previous = prev.link
        last = current
        (right - left + 1).times {
            last = last.link
        }
    
        prev = previous
        while current != last
            upcoming = current.link
            current.link = prev
            prev = current
            current = upcoming
        end
        
        previous.link = prev
        start.link = last
    end
end

list = List.new
10.downto(1).each { |x|
    list.add(x)
}

list.display
list.reverse(2, 5)
list.display

