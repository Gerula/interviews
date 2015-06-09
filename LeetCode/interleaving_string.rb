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

    private :inter_rec
end

puts "aadbbcbcac".inter("aabcc", "dbbca")
puts "aadbbbaccc".inter("aabcc", "dbbca")

