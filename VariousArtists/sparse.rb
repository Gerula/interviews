# I know this one from programming pearls

class WeirdArray
    def initialize(size)
        @size = size
        @array = allocate(size)
        @dense = allocate(size)
        @sparse = allocate(size)
        @threshold = 0
    end
    
    def [](i)
        raise("Not initialized at #{i}") unless initialized?(i)
        @array[i]
    end

    def []=(i, value)
        @array[i] = value
        
        unless initialized?(i)
            @dense[@threshold] = i
            @sparse[i] = @threshold
            @threshold += 1
        end
    end

    def allocate(size)
        result = Array.new(size)
        1.upto(size-1).each { |i|
             result[i] = Random.rand()
        }

        result
    end

    def initialized?(index)
        @sparse[index] < @threshold &&
        @dense[@sparse[index]] == index
    end
end

array = WeirdArray.new(20)
begin
    puts array[1]
rescue
    puts "Continue was not initialized"
end

array[1] = 2
array[2] = 3
puts array[1],array[2]

