#  Given an unsorted array of integers, find the length of the longest consecutive elements sequence.
#
#  For example,
#  Given [100, 4, 200, 1, 3, 2],
#  The longest consecutive elements sequence is [1, 2, 3, 4]. Return its length: 4.
#
#  Your algorithm should run in O(n) complexity. 
#


class Array
    def longest_consec
        hash = self.inject({}) { |acc, x|
            acc.merge({x => 0})
        }

        self.each { |x|
            flag = false
            unless hash[x - 1].nil?
                hash[x - 1] += 1
                flag = true
            end
            unless hash[x + 1].nil? 
                hash[x + 1] += 1
                flag = true
            end
            hash.delete(x) if !flag            
        }
        
        max = 0
        while !hash.empty?
           min = hash.keys.min
           count = 0
           while !hash[min].nil?
             count += 1
             hash.delete(min)
             min += 1
           end
           max = [max, count].max
        end
        
        max
    end
end

puts [100, 4, 200, 1, 3, 2].longest_consec.inspect
