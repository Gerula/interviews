# Given an array of size n, find the majority element. The majority element is the element that appears more than ⌊ n/2 ⌋ times.
#
# You may assume that the array is non-empty and the majority element always exist in the array.
#

class Array
    def majority
        element = self.first
        majority = 1
        self[1..-1].each do |x|
            if element == x
                majority += 1
            else
                majority -= 1
                if majority == 0
                    element = x
                    majority = 1
                end
            end
        end

        element
    end
end

[[1, 1, 1, 2, 3, 1], [2, 3, 4], [2, 1, 2, 3, 2, 2, 4]].each do |x|
    puts "#{x.inspect} = #{x.majority}"
end
