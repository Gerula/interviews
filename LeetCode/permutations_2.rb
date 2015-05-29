#  Given a collection of numbers that might contain duplicates, return all possible unique permutations.
#
#  For example,
#  [1,1,2] have the following unique permutations:
#  [1,1,2], [1,2,1], and [2,1,1]. 
#


class Array
    def uniq_permutations
        @perms = []
        uniq_permutations_rec(self.dup, 0, self.length - 1)
        return @perms.uniq
    end

    def uniq_permutations_rec(a, start, length)
        if start == length
            @perms << a.dup
            return
        end

        start.upto(length) { |i|
            a[i], a[start] = a[start], a[i]
            uniq_permutations_rec(a, start + 1, length)
            a[i], a[start] = a[start], a[i]
        }
    end

    private :uniq_permutations_rec
end

puts [1, 1, 2].uniq_permutations.inspect
