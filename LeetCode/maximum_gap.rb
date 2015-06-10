# Given an unsorted array, find the maximum difference between the successive elements in its sorted form.
#
# Try to solve it in linear time/space.
#
# Return 0 if the array contains less than 2 elements.
#
# You may assume all elements in the array are non-negative integers and fit in the 32-bit signed integer range.
#

class Array
    class Bucket < Struct.new(:high, :low)
    end

    def max_gap
        min = self.min
        max = self.max

        buckets = (0..self.size).map { |x|
            nil
        }

        interval = self.size.to_f / (max - min)

        self.each { |x|
            bucket = ((x - min) / interval).to_i
            if buckets[bucket].nil? 
                buckets[bucket] = Bucket.new(x, x)
            else
                buckets[bucket].low = [buckets[bucket].low, x].min
                buckets[bucket].high = [buckets[bucket].high, x].max
            end
        }

        result = 0
        prev = buckets.first.high
        buckets.select{ |x| x}.each { |bucket|
            result = [result, bucket.low - prev].max
            prev = bucket.high
        }

        result
    end

    def self.generate
        1.upto(Random.rand(5..20)).inject([]) { |acc, x|
            acc << Random.rand(1..100)
        }
    end
end

a = Array::generate
puts a.inspect
puts a.sort.inspect
puts a.max_gap
puts a.sort.each_cons(2).map {|a, b| b - a}.max
