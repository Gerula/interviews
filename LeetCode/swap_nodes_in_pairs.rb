#  Given a linked list, swap every two adjacent nodes and return its head.
#
#  For example,
#  Given 1->2->3->4, you should return the list as 2->1->4->3.
#
#  Your algorithm should use only constant space. You may not modify the values in the list, only nodes itself can be changed. 
#

class ListNode < Struct.new(:value, :link)
end

class List
    def initialize
        @root = nil
    end

    def << value
        @root = ListNode.new(value, @root)
    end

    def print_list
        it = @root
        while !it.nil?
            print "#{it.value} "
            it = it.link
        end
        puts
    end

    def reverse_2
       prev = nil
       current = @root
       new_root = @root.link
       next_node = @root.link
       while !current.nil? && !next_node.nil?
           prev.link = next_node unless prev.nil?
           current.link = next_node.link
           next_node.link = current
           prev = current
           current = current.link
           next_node = current.nil? ? nil: current.link
       end 

       @root = new_root
    end
end

list = List.new
6.downto(1).each {|x|
    list << x
}

list.print_list
list.reverse_2
list.print_list
