class SkipList
    def self.int_min
        return - 2 ** (0.size * 8 - 2)
    end

    def self.max_levels
        return 10
    end

    class Node < Struct.new(:value, :right)
    end

    def initialize
        @head = Node.new(SkipList::int_min, [])
        @levels = 1
    end

    def add(value)
        current_level = 0
        level_mask = Random.rand(1..1000000)
        while level_mask & 1 != 0 && current_level < SkipList::max_levels
            current_level += 1
            level_mask >>= 1
            @levels += 1 if current_level = @levels
        end
        
        current = @head
        new_node = Node.new(value, [])
        (@levels - 1).downto(0).each { |i|
            while current && current.right[i] 
                break if current.right[i].value > value
                current = current.right[i]
            end

            if i <= current_level 
                new_node.right[i] = current.right[i]
                current.right[i] = new_node
            end
        }
    end

    def find(value)
        current = @head
        (@levels - 1).downto(0).each { |i|
            while current && current.right[i]
                break if current.right[i].value > value
                current = current.right[i]
            end

            return current if current.value == value
        }

        return nil
    end

    def display 
        (@levels - 1).downto(0).each { |i|
            current = @head
            while current
                print current.right[i] ? " #{current.value} " : " - "
                current = current.right[0]
            end
            puts
        }
    end
end

list = SkipList.new
0.upto(10).each { |i|
    list.add(Random.rand(1..9))
}

list.display
puts list.find(2).value
