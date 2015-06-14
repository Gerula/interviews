# Given an array of size n, find the majority element. The majority element is the element that appears more than ⌊ n/2 ⌋ times.
#
# You may assume that the array is non-empty and the majority element always exist in the array.
#

class Array
    def majority
        element = nil
        majority = 0
        self.each do |x|
            if majority == 0
                element = x
                majority = 1
            else
                majority += element == x ? 1 : -1
            end
        end
        
        majority = self.inject(0){|acc, x| acc + (x == element ? 1 : 0)}
        return element if majority > self.size / 2
        return nil
    end
end

[[1, 1, 1, 2, 3, 1], [2, 3, 4], [2, 1, 2, 3, 2, 2, 4]].each do |x|
    puts "#{x.inspect} = #{x.majority}"
end
