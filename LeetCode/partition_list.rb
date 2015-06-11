# Given a linked list and a value x, partition it such that all nodes less than x come before nodes greater than or equal to x.
#
# You should preserve the original relative order of the nodes in each of the two partitions.
#
# For example,
# Given 1->4->3->2->5->2 and x = 3,
# return 1->2->2->4->3->5. 
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
            print("#{it.value} ")
            it = it.link
        end
        puts
    end

    def partition
        pivot = Random.rand(1..30)
        puts pivot
        count = 0
        it = @root
        last = it
        while it
            last = it
            count += 1
            it = it.link
        end
        
        it = @root
        prev = nil
        count.times {
            successor = it.link
            if it.value >= pivot
                if prev
                    prev.link = successor
                    prev = prev.link
                else
                    @root = successor
                end

                it.link = nil
                last.link = it
                last = last.link
            end
            it = successor
        }
    end
end

list = List.new
Random.rand(5..10).times {
    list.add(Random.rand(1..30))
}

list.display
list.partition
list.display
