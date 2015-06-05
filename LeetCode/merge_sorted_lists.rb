# Merge two sorted linked lists and return it as a new list. The new list should be made by splicing together the nodes of the first two lists.
#

class Node < Struct.new(:value, :link)
end

class List
    attr_accessor :root

    def initialize
        @root = nil
    end

    def add(value)
        @root = Node.new(value, @root)
    end

    def display
        print "List:["
        it = @root
        while it
            print "#{it.value} "
            it = it.link
        end

        puts "]" 
    end

    def self.merge(list_1, list_2)
        first = list_1.root
        second = list_2.root
        new_root = nil
        new_prev = nil

        while first && second
            if first.value > second.value
                if new_root.nil?
                    new_root = second
                    prev = new_root
                else
                    prev.link = second
                    prev = prev.link
                end
                second = second.link
            else
                if new_root.nil?
                    new_root = first
                    prev = first
                else
                    prev.link = first
                    prev = prev.link
                end
                first = first.link
            end        
        end

        while first
            prev.link = first
            first = first.link
        end

        while second
            prev.link = second
            second = second.link
        end

        new_list = List.new
        new_list.root = new_root
        return new_list
    end
end

list_1 = List.new
list_2 = List.new

(1..20).reverse_each{ |i|
    i % 2 == 0? list_1.add(i) : list_2.add(i)    
}

list_1.display
list_2.display

List.merge(list_1, list_2).display
