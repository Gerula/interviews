class String
    def to_int
        sign = self[0] == '-' ? -1 : 1
        self.chars.inject(0) { |acc, c|
            digit = c.ord - '0'.ord
            if c != '-'
                if !digit.between?(0, 9) 
                    raise("Invalid number")
                end

                acc * 10 + digit
            else
                acc
            end

        } * sign
    end
end

class Fixnum
    def to_string
        result = ""
        sign = ""
        n = self
        if n < 0 
            sign = "-"
            n *= -1
        end

        while n > 0
            div, mod = n.divmod(10)
            result = (mod + '0'.ord).chr + result
            n = div
        end
        sign + result
    end
end

puts [1, 123, -432].map { |x| x.to_string }.inspect
puts ["1", "123", "-423"].map { |x| x.to_int}.inspect
