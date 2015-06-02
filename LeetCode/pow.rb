# Implement pow(x, n)
#

class Fixnum
    def pow(n)
        result = 1
        n.times {
            result *=self
        }

        result
    end

    def pow_wow(n)
        result = 1
        while n > 1 
            if n % 2 == 0
                result *= self * self
            else
                result *= self * self * self
            end
            
            n /= 2
        end

        result
    end
end

puts 100.pow(2)
puts 2.pow(3)
puts 100.pow_wow(2)
puts 2.pow_wow(3)
