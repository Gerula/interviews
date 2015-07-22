class Array
    def randomize
        (self.size - 1).downto(1).each { |i|
            target = Random.rand(0..i)
            self[target], self[i] = self[i], self[target]
        }

        return self
    end
end

puts [1, 2, 3, 4, 5, 6, 7, 8, 9, 10].shuffle.inspect
puts [1, 2, 3, 4, 5, 6, 7, 8, 9, 10].randomize.inspect

