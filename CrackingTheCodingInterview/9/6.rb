#  Given a matrix in which each row and each column is sorted, write a method to find an element in it.
#

size = 5

a = []
partial = []

(0..size**2 - 1).each { |i|
    partial.push(i)
    if (i + 1)  % size == 0
        a.push(partial)
        partial = []
    end 
}

puts a.inspect
a.each{|i|
    puts i.inspect
}

class << a
    def find_stuff(value)
        line = 0
        column = self.size - 1
        while line.between?(0, self.size - 1) && column.between?(0, self.size - 1)
            if self[line][column] == value
                return [line, column]    
            end

            if self[line][column] > value
                column -= 1
            else
                line += 1
            end
        end

        return [-1, -1]
    end
end

puts a.find_stuff(8).inspect
puts a.find_stuff(18).inspect
puts a.find_stuff(20).inspect
puts a.find_stuff(29).inspect
