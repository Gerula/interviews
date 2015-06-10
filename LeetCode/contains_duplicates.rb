# Given an array of integers, find if the array contains any duplicates. Your function should return true if any value appears at least twice in the array, and it should return false if every element is distinct. 
#

class Array
    def contains_dups?
        return !self.inject({}) { |acc, x|
            acc[x] ||= 0
            acc[x] += 1
            acc
        }.find{|x, y| y == 2 }.nil?
    end
end

[[1, 1, 2, 3], [1, 2, 3], [1, 2, 2, 3]].each { |x|
    puts "#{x.inspect} - #{x.contains_dups?}"
}
