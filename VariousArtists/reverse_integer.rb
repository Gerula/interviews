# Always remember: it may overflow
#

class Fixnum
    def reverse
        sign = self > 0 ? 1 : -1

        result = 0
        current = self.abs
        while current != 0
            div, mod = current.divmod(10)
            result = result * 10 + mod
            current = div
        end

        result * sign
    end
end

[123, 1, 2, 3563, -12].each { |x|
    puts "#{x} <-> #{x.reverse}"
}
