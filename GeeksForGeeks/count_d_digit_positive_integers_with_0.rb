#   http://www.geeksforgeeks.org/count-d-digit-positive-integers-with-0-as-a-digit/
#   Given a number d, representing the number of digits of a positive integer.
#   Find the total count of positive integer (consisting of d digits exactly) which have at-least one zero in them.

require 'test/unit'
extend Test::Unit::Assertions

class Fixnum
    def count_zero
        #   [d1, d2, d3, ... ,dn]
        #   each digit except d1 can be 0..9, d1 can be 1..9
        #   so there are K = 9 * (10 ** (n - 1)) total numbers with exactly n digits
        #   
        #   L = 9 ** n - total numbers with exactly n digits with all digits != 0
        #
        #   Answer is K - L

        9 * (10 ** (self - 1)) - 9 ** self
    end

    def count_zero_stupid
        (10 ** (self - 1)...(10 ** self)).count { |x|
            x.to_s.include?("0")
        }
    end
end

(1..6).each { |i|
    assert_same(i.count_zero_stupid, i.count_zero)
    puts "#{i} #{i.count_zero}"
}

