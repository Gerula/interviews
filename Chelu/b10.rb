# Running median
#

class Heap
    attr_accessor :size

    def initialize(comparer)
        @size = 0
        @data = []
        @comparer = comparer
    end

    def head(extract = false)
        return nil if @size == 0
        min = @data[0]
        return min if !extract
        @size -= 1
        @data[0] = @data[size]
        @data[size] = nil
        heapify_down(0)
        return min
    end    

    def add(value)
        @data[size] = value
        @size += 1
        heapify_up
    end

    def heapify_down(index)
        while index < @size
            optimum_index = index
            if left(index) < @size && !@comparer.call(@data[index], @data[left(index)])
                optimum_index = left(index)
            end
            if right(index) < @size && !@comparer.call(@data[optimum_index], @data[right(index)])
                optimum_index = right(index)
            end

            if optimum_index == index
                break
            end

            @data[index], @data[optimum_index] = @data[optimum_index], @data[index]
            index = optimum_index 
        end 
    end

    def heapify_up
        index = @size - 1 
        while index > 0 && @comparer.call(@data[index], @data[parent(index)])
            @data[index], @data[parent(index)] = @data[parent(index)], @data[index]
            index = parent(index)
        end     
    end
    
    def parent(index)
        (index - 1) / 2
    end
    
    def right(index)
        index * 2 + 2
    end

    def left(index)
        index * 2 + 1
    end

    private :heapify_down
    private :heapify_up
end

max_heap = Heap.new(->(a,b) { a > b })
min_heap = Heap.new(->(a,b) { a < b })
c = 1
median = 0
while c!=0
    puts "Gimme number > "
    c = gets.chomp.to_i
    
    if c > median
        min_heap.add(c)
    else
        max_heap.add(c)
    end

    while (min_heap.size - max_heap.size).abs >= 2
        if min_heap.size > max_heap.size
            max_heap.add(min_heap.head(true))
        else
            min_heap.add(max_heap.head(true))
        end
    end

    median = min_heap.size >= max_heap.size ? min_heap.head : max_heap.head
    puts "Current median is #{median}"
end
