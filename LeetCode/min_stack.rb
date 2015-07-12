# Min-stack
#

class MinStack
    def initialize
        @data = []
        @size = 0
    end

    def peek
        return last[0] unless last.nil?
        return nil
    end

    def min
        return last[1] unless last.nil?
        return nil
    end

    def last
        return @data[@size - 1] unless @size == 0
        return nil
    end

    private :last

    def push(value)
        min = last.nil? ? value : [last[1], value].min
        @data[@size] = [value, min]
        @size += 1
    end

    def pop
        unless @size == 0
            result = @data[@size - 1][0]
            @data[@size - 1] = nil
            @size -= 1;
            return result;
        end
        return nil
    end
end

stack = MinStack.new

Random.rand(2..10).times {
    stack.push(Random.rand(1..10)); puts "Top: #{stack.peek} min:#{stack.min}"
}

puts "Deleting"

while stack.peek
    stack.pop; puts "Top: #{stack.peek} min:#{stack.min}"
end


