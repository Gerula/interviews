# http://careercup.com/question?id=5200686994161664
#
# Given an array int32 arr[] of size n, return the number of non-empty contigious subarrays whose sum lies in range [a, b]
#

require 'test/unit'
extend Test::Unit::Assertions

class Array
    def subarrays(low, high)
        result = 0
        pre = self.inject([]) { |acc, x|
            acc << (acc.size == 0 ? x : acc[-1] + x)
        }

        post = self.reverse.inject([]) { |acc, x|
            acc << (acc.size == 0 ? x : acc[-1] + x)
        }.reverse

        for i in 0...(self.size - 1)
            for j in (i + 1)...self.size
                result += 1 if (pre[j] - pre[i] + self[i]).between?(low, high)
            end
        end

        return result + self.count{ |x| x.between?(low, high) }
    end
end

assert_equal(4, [1, 2, 3].subarrays(0, 3))
assert_equal(3, [-2, 5, -1].subarrays(-2, 2))
