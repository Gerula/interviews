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


puts [1, 2, 3, 30, 25, 26, 27, 28].map { |x| "#{x}=#{x.to_column}"}
