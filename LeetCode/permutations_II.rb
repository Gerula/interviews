#  Given a collection of numbers that might contain duplicates, return all possible unique permutations.
#
#  For example,
#  [1,1,2] have the following unique permutations:
#  [1,1,2], [1,2,1], and [2,1,1]. 
#

class Array
    def perms
        perms_rec(self.dup, 0)
    end

    def perms_rec(a, i)
        if i == a.size - 1
            puts a.inspect
        end

        i.upto(a.size - 1).each { |j|
            unless a[i] == a[j] && i != j
                a[i], a[j] = a[j], a[i]
                perms_rec(a, i + 1)
                a[i], a[j] = a[j], a[i]
            end
        }
    end
end

[1, 1, 2].perms
