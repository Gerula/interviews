#  Given a collection of numbers, return all possible permutations.
#
#  For example,
#  [1,2,3] have the following permutations:
#  [1,2,3], [1,3,2], [2,1,3], [2,3,1], [3,1,2], and [3,2,1]. 
#

class Array
    def permutations
        permutations_rec(self.dup, 0, self.size - 1)
    end

    def permutations_rec(array, start, length) 
        if start == length
            puts array.inspect
            return
        end

        start.upto(length).each {|i|
            array[i], array[start] = array[start], array[i]
            permutations_rec(array, start + 1, length)
            array[i], array[start] = array[start], array[i]
        }

    end

    private :permutations_rec
end

[1, 2, 3].permutations
