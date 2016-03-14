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
# 0      0 - 0
# 1      1 - 1
# 2     10 - 1
# 3     11 - 2
# 4    100 - 1
# 5    101 - 2
# 6    110 - 2
# 7    111 - 3
# 8   1000 - 1
# 9   1001 - 2
# 10  1010 - 2
# 11  1011 - 3
# 12  1100 - 2
# 13  1101 - 3
# 14  1110 - 3
# 15  1111 - 4
#   Fucking GRAY CODE it!!
    acc = [0]
    while acc.size < num + 1
        acc += acc.map { |x| x + 1 }
    end

    acc.take(num + 1)
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

(1...100).each { |i|
    assert_equal(generate_bits(i), count_bits(i), i.to_s)
}
