#  An N sized array contains integers starting from 1. Find the first missing integer. For example, in [4, 1, 3, 2, 6] the first missing integer is 5. 
#

a = [4, 1, 3, 2, 6]

class Array
    def missing
        c = self.dup
        i = 0
        0.upto(c.size - 1).each { |i|
            while c[i] != i + 1 && c[c[i] - 1]  && c[i] < c[c[i] - 1]
               target = c[i] - 1
               c[i], c[target] = c[target], c[i]
            end
        }

        return c.each_with_index.map { |x, y| [x, y]}.find { |x, y| x != y + 1}[1] + 1
    end
end

puts a.missing.inspect
