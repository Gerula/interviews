#  Given s1, s2, s3, find whether s3 is formed by the interleaving of s1 and s2.
#
#  For example,
#  Given:
#  s1 = "aabcc",
#  s2 = "dbbca",
#
#  When s3 = "aadbbcbcac", return true.
#  When s3 = "aadbbbaccc", return false. 
#

class String
    def inter(first, second)
        inter_rec(self, first, second)
    end

    def inter_rec(s, first, second)
        return true if s.empty? && first.empty? && second.empty?
        return false if s.empty?
        return s[0] == first[0] && inter_rec(s[1..-1], first[1..-1], second) ||
               s[0] == second[0] && inter_rec(s[1..-1], first, second[1..-1])
    end

    def inter_dp(first, second)
        match = Array.new(first.size + 1) { |x|
            Array.new(second.size + 1) { |y|
                false
            }
        }
        0.upto(first.size).each { |i|
            0.upto(second.size).each { |j|
                if i == 0 && j == 0
                    match[i][j] = true 
                    next
                end 
                if i == 0 && second[j - 1] == self[j - 1]
                    match[i][j] = match[i][j - 1]
                    next
                end
                if j == 0 && first[i - 1] == self[j - 1]
                    match[i][j] = match[i - 1][j]
                    next
                end
                if first[i - 1] != self[i + j - 1] && second[i - 1] != self[i + j - 1]
                    match[i][j] = match[i - 1][j] || match[i][j - 1]
                    next
                end
                if first[i - 1] == self[i + j - 1] && second[i - 1] != self[i + j - 1]
                    match[i][j] = match[i - 1][j]
                    next
                end
                if first[i - 1] != self[i + j - 1] && second[i - 1] == self[i + j - 1]
                    match[i][j] = match[i][j - 1]
                    next
                end
            }
        }

        match[first.size][second.size]
    end

    private :inter_rec
end

puts "aadbbcbcac".inter("aabcc", "dbbca")
puts "aadbbbaccc".inter("aabcc", "dbbca")

puts "aadbbcbcac".inter_dp("aabcc", "dbbca")
puts "aadbbbaccc".inter_dp("aabcc", "dbbca")

