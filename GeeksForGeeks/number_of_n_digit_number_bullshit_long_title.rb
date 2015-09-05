# http://www.geeksforgeeks.org/count-total-number-of-n-digit-numbers-such-that-the-difference-between-the-sum-of-even-digits-and-odd-digits-is-1/
# Given a number n, we need to count total number of n digit numbers 
# such that the sum of even digits is 1 more than the sum of odd digits.
# Here even and odd means positions of digits are like array indexes, for example, 
# the leftmost (or leading) digit is considered as even digit, next to leftmost is considered as odd and so on.  
#
# Input:  n = 2
# Output: Required Count of 2 digit numbers is 9
# Explanation : 10, 21, 32, 43, 54, 65, 76, 87, 98.
#
# Input:  n = 3
# Output: Required Count of 3 digit numbers is 54
# Explanation: 100, 111, 122, ......, 980

require 'test/unit'
extend Test::Unit::Assertions

class Fixnum
    def long_ass_problem
        (10 ** (self - 1)...10**self).count{ |x| x.off_by_one? }
    end

    def long_ass_backtrack
        count = [0]
        back_track([], self, 0, 0, count)
        return count.first
    end

    def back_track(number, digits_max, odd_sum, even_sum, count) 
        if (number.size == digits_max)
            if even_sum == odd_sum + 1
                count[0] += 1
            end
            return
        end

        (0...10).each { |i|
            unless i == 0 && number.empty?
                number.push(i)
                back_track(number,
                           digits_max,
                           number.size % 2 == 0 ? odd_sum + i : odd_sum,
                           number.size % 2 == 0 ? even_sum : even_sum + i,
                           count)
                number.pop
            end
        }
    end

    def off_by_one?
        number = self
        first = 0
        second = 0
        flag = false
        while number != 0
            div, mod = number.divmod(10)
            if flag 
                first += mod
                flag = false
            else
                second += mod
                flag = true
            end

            number = div
        end

        return flag ? second == first + 1 : first == second + 1
    end
end

assert_equal(54, 3.long_ass_backtrack)
assert_equal(9, 2.long_ass_backtrack)
assert_equal(54, 3.long_ass_problem)
assert_equal(9, 2.long_ass_problem)
