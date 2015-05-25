#  Follow up for "Remove Duplicates":
#  What if duplicates are allowed at most twice?
#
#  For example,
#  Given sorted array nums = [1,1,1,2,2,3], 
#

require 'pry'

class Array
    def dedup!
        write_point = 1
        i = 1
        while i < self.length
            if self[i] != self[i - 1]
                self[write_point] = self[i]
                write_point += 1
            end
            i += 1
        end
        binding.pry
        write_point.upto(self.length - 1).each {|i|
            self[i] = nil
        }
    end
end

[[1, 1, 1, 2, 2, 3], [1, 2, 2, 3, 3, 3, 4]].each{ |x|
    x.dedup!
    puts x.inspect
}
