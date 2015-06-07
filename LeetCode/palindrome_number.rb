# Determine whether an integer is a palindrome. Do this without extra space.
#

class Fixnum
    def palindrome?
        left = 1
        while self / left * 10 > 0 
           left *= 10
        end
        
        left /= 10
        
        n = self
        while n != 0 
            first = n / left 
            second = n % 10
            n = n % first / 10
            return false if first != second
            left = left / 10
        end

        true
    end
end

[123, 1, 12321].each {|x|
    puts "#{x} - #{x.palindrome?}"
}
