class Entry
    def initialize(val = nil, link = nil)
        @val = val
        @link = link
    end
    
    attr_accessor :val
    attr_accessor :link
end

class Linked_list
    def initialize(val)
        @head = Entry.new(val)
    end

    def fill_with_shit
        size = Random.rand(15)
        head = @head
        1.upto(size).each {|i|
            head.link = Entry.new(Random.rand(10))
            head = head.link
        }
    end

    def print_list
        head = @head
        while head
            print "#{head.val} "
            head = head.link
        end
        
        puts
    end

    def reverse
        previous = nil
        current = @head
        next_node = nil
        while current
            next_node = current.link
            current.link = previous
            previous = current
            current = next_node
        end

        @head = previous
    end

    def make_cycle(n)
        last = @head
        while last.link
            last = last.link
        end
        
        cycle = @head
        1.upto(n - 1).each {
            if !cycle
                raise("List is too short")
            end

            cycle = cycle.link
        }
        puts "Added cycle at #{n}th element with value #{cycle.val}"
        last.link = cycle
    end

    attr_accessor :head
end

