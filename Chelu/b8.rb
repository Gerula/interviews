#  Given an array of positive and negative integers. Find the starting index and length of sub-array with the largest sum. 
#

class Array
    def largest_sum
        max_start = 0
        max_end = 0
        max = -100
        max_local = max
        local_start = 0
        self.each.with_index {|x, i|
            if max_local + x > 0
                max_local += x
            else
                max_local = 0
                local_start = i + 1
            end
            
            local_end = i
            if max_local > max
                max_start, max_end = local_start, local_end
                max = max_local
            end
        }

        [max_start, max_end, max]
    end
end

puts [1, -1, -2, -3, 5, 6, 9, -3].largest_sum.inspect
