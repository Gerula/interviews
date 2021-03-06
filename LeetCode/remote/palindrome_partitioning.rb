#   https://leetcode.com/problems/palindrome-partitioning/
#    Given a string s, partition s such that every substring of the partition is a palindrome.
#
#    Return all possible palindrome partitioning of s.
#
#    For example, given s = "aab",
#    Return
#
#      [
#       ["aa","b"],
#       ["a","a","b"]
#      ]

#   https://leetcode.com/submissions/detail/56048139/
#
#   Submission Details
#   21 / 21 test cases passed.
#       Status: Accepted
#       Runtime: 208 ms
#           
#           Submitted: 0 minutes ago
#   You are here!
#   Your runtime beats 100.00% of rubysubmissions. Yeah!!
def partition(s)
    palindrome = Array.new(s.size) {
        Array.new(s.size)
    }
    
    cuts = [[]]
    
    (0...s.size).each { |i|
        (0..i).each { |j|
            palindrome[j][i] = if i == j
                                    true
                               elsif i == j + 1
                                    s[i] == s[j]
                               else
                                    s[i] == s[j] && palindrome[j + 1][i - 1]
                               end

            next if !palindrome[j][i] || cuts[j - 1].nil? && j > 1
            cuts[i] ||= []
            cuts[i] << cuts[j - 1].map { |x| x + [s[j..i]] }.flatten(1)
        }
    }
    
    puts "#{cuts}"
    cuts[s.size - 1]
end

partition("aab")
#puts "#{partition("aab")}"
