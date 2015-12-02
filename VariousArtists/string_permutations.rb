# permute string

class String
    def permute
        return [self] if self.size == 1
        self[1..-1].permute.map { |x|
            (0...self.size).map { |i|
                "#{x[0, i]}#{self[0]}#{x[i..-1]}"
            }
        }.flatten
    end
end

puts "gerula".permute.inspect
puts "abc".permute.inspect

