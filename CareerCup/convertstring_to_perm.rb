# Convert string to permutations using only adjacent swaps
#
# Example: CAT TAC
#
# CAT CTA TCA TAC
#

class String
    def perms(target)
        result = []
        for i in 0..self.size - 1
            j = i
            while self[i] != target[j]
                j += 1
            end
            while j > i
                self[j], self[j - 1] = self[j - 1], self[j]
                result << self.dup
                j -= 1
            end
        end

        result
    end
end

[["CAT", "TAC"]].each { |x|
    puts "#{x[0]} #{x[0].perms(x[1])}"
}
