class Node < Struct.new(:value, :link)
end

class List
    def initialize
        @head = nil
        @size = 0;
    end

    def add(value)
        @head = Node.new(value, @head)
        @size += 1
    end

    def rotate(k)
        if k > @size
            return
        end

        it = @head
        (@size - k - 1).times {
            it = it.link
        }

        last = it
        while last.link
            last = last.link
        end

        old_head = @head
        @head = it.link
        it.link = nil

        last.link = old_head
    end

    def inspect
        s = ""
        it = @head
        while it
            s << "#{it.value} "
            it = it.link
        end
        return s
    end
end

list = List.new
5.downto(1).each { |x|
    list.add(x)
}

puts list.inspect
list.rotate(2)
puts list.inspect
