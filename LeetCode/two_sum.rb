# Given an array of integers, find two numbers such that they add up to a specific target number.
#

class Array
    def two_sum(sum)
        hash = self.inject({}) {|acc, x|
            acc[x] ||= 0
            acc[x] += 1
            acc
        }

        return self.select{ |x| 
            hash[x] && hash[sum - x] && x < sum - x
        }.map {|x|
            [x, sum - x]
        }
    end
end

puts [2, 7, 1, 14].two_sum(9).inspect

