#  You are given two sorted arrays, A and B, and A has a large enough buffer at the end to hold B. Write a method to merge B into A in sorted order.
#

a = [1, 3, 5, 7, 9]
b = [2, 4, 6, 8]

class Array
    def merge_with!(b)
        total = self.length + b.length - 1
        this = self.length - 1
        other = b.length - 1

        while this >= 0 && other >= 0
            if self[this] > b[other]
                self[total] = self[this]
                this -= 1
            else
                self[total] = b[other]
                other -= 1
            end
            total -= 1
        end

        while other >= 0
            a[total] = b[other]
            total -= 0
            other -= 0
        end
    end
end

a.merge_with!(b)
puts a.inspect
