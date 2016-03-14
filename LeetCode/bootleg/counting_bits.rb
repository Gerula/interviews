#   http://lcoj.tk/problems/counting-bitssyedee/
#   You will be given a non negative integer number num.
#   For every numbers i in the range 0<=i<=num calculate the number of 1's in their binary representation and return them in an array.
#
#   Example
#   For num=5 you should return [0,1,1,2,1,2].
#
#   Follow up:
#   Your solution should be of O(n) run time.
#   Space complexity should be O(n).
#   Can you do it like a boss? Do it without using any builtin function like __builtin_popcount in c++ or in any other language.

require 'test/unit'
extend Test::Unit::Assertions

# @param {Integer} num
# # @return {Integer[]}
def count_bits(num)
    generate_bits(num)
end

class Fixnum
    def bit_count
        count = 0
        n = self
        while n != 0
            n = n & (n - 1)
            count += 1
        end

        count
    end
end

def generate_bits(num)
    (0..num).map { |x| x.bit_count }
end

assert_equal([0, 1, 1, 2, 1, 2], count_bits(5))
