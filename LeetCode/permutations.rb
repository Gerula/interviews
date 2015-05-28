#  Given a collection of numbers, return all possible permutations.
#
#  For example,
#  [1,2,3] have the following permutations:
#  [1,2,3], [1,3,2], [2,1,3], [2,3,1], [3,1,2], and [3,2,1]. 
#

class Array
    def permutations
        permutations_rec(self, [])
    end

    def permutations_rec(array, perm)
        if perm.size == self.size
            puts perm.inspect
            return
        end

        array.each { |x|
            permutations_rec(array - [x], perm + [x]) 
        }
    end

    private :permutations_rec
end

[1, 2, 3].permutations
