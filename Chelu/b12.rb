#  Given an array of arrays of sorted ints. Returned the kth largest. 
#

input = []
1.upto(100).each {|x|
    input[x / 10] ||= []
    input[x / 10] << x
}

class MaxHeap
    attr_accessor :size

    def initialize
        @size = 0
        @data = []
    end

    def head
        @data[0]
    end
    
    def parent(index)
        (index - 1) / 2
    end

    def add(value)
        @data[@size] = value
        @size += 1
        heapify_up
    end

    def heapify_up
        index = @size - 1
        while index > 0 && @data[index] > @data[parent(index)]
            @data[index], @data[parent(index)] = @data[parent(index)], @data[index]
            index = parent(index)
        end
    end
end

heap = MaxHeap.new
k = 19
count = 0
found = false
while !found 
    0.upto(input.size - 1).each { |x|
        heap.add(input[x][count]) if count < input[x].size
        found = heap.size == k
        puts heap.inspect if found
        break if found
    }
    count += 1
end

puts heap.head


