class Fixnum
    def gcd(other)
        this = self
        while this != other && this * other != 0
            max, min = [this, other].max - [this, other].min, [this, other].min
            this, other = min, max
        end

        this
    end
end

puts [[10, 25], [14, 49], [0, 1]].map { |x| "#{x.inspect} - #{x[0].gcd(x[1])}"}
