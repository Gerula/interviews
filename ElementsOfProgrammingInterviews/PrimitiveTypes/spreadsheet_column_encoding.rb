class Fixnum
    def to_column
        x = self
        result = ""
        alphabet_size = 26
        while x > 0
            x -= 1
            div, mod = x.divmod(alphabet_size)
            x = div 
            result = (mod + 'A'.ord).chr + result
        end

        result
    end
end

class String
    def to_column
        alphabet_size = 26
        self.chars.inject(0) { |acc, c|
            acc * alphabet_size + c.ord - 'A'.ord + 1
        }
    end
end


puts [1, 2, 3, 30, 25, 26, 27, 28].map { |x| "#{x}=#{x.to_column}"}
puts ["A", "B", "C", "AD", "Y", "Z", "AA", "AB"].map { |x| "#{x}=#{x.to_column}"}
