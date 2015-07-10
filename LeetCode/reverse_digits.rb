class Fixnum
    def reverse
        negative = self < 0 ? -1 : 1
        result = 0
        n = self * negative
        while n != 0
            result *= 10
            div, mod = n.divmod(10)
            n = div
            result += mod
        end

        result * negative
    end
end

[123, 322, -12345].each { |x|
    puts "#{x} - #{x.reverse}"
}
