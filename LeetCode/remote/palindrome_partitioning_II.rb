#   https://leetcode.com/problems/palindrome-partitioning-ii/
#    Given a string s, partition s such that every substring of the partition is a palindrome.
#
#    Return the minimum cuts needed for a palindrome partitioning of s.
#
#    For example, given s = "aab",
#    Return 1 since the palindrome partitioning ["aa","b"] could be produced using 1 cut. 
#    https://leetcode.com/submissions/detail/56025444/
#
#    Submission Details
#    28 / 28 test cases passed.
#       Status: Accepted
#       Runtime: 1212 ms
#           
#           Submitted: 0 minutes ago
# @param {String} s
# @return {Integer}
def min_cut(s)
    palindrome = Array.new(s.size) {
        Array.new(s.size)
    }
    
    min_cuts = (0...s.size).to_a
    
    (1...s.size).each { |i|
        (0..i).each { |j|
            palindrome[i][j] = if i == j
                                    true
                               elsif j + 1 == i
                                    s[i] == s[j]
                               else
                                    s[i] == s[j] && palindrome[i - 1][j + 1]
                               end
            min_cuts[i] = [min_cuts[i], j == 0 ? 0 : 1 + min_cuts[j - 1]].min if palindrome[i][j]
        }
    }
    
    min_cuts[s.size - 1]
end
