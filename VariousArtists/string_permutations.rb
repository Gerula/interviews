# permute string

class String
    def permute
        return [self] if self.size == 1
        permutations = self[1..-1].permute
        char = self[0]
        result = []
        permutations.each { |x|
            for i in 0..self[1..-1].size
                result << "#{x[0, i]}#{char}#{x[i..-1]}"
            end
        }

        result
    end
end

puts "gerula".permute.inspect
puts "abc".permute.inspect

