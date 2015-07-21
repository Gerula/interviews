# Palindrome Partitioning Total Accepted: 43086 Total Submissions: 160653
#
# Given a string s, partition s such that every substring of the partition is a palindrome.
#
# Return all possible palindrome partitioning of s.
#
# For example, given s = "aab",
# Return
#
#   [
#     ["aa","b"],
#     ["a","a","b"]
#   ]
#
# 21 / 21 test cases passed.
#   Status: Accepted
#   Runtime: 184 ms
#       
#       Submitted: 0 minutes ago
#

def partition(s)
    result = []
    palindrome_part(s.chars, result, [])
    result
end

def palindrome_part(s, result, temp)
    if !s.any?
        result << temp
        return
    end

    for i in 1..s.size
        if palindrome?(s[0, i])
            palindrome_part(s[i..-1], result, temp + [s[0, i].join("")])
        end
    end
end

def palindrome?(s)
    i = 0
    j = s.size - 1
    while i < j && s[i] == s[j]
        i += 1
        j -= 1
    end
    
    return i >= j
end

puts partition("aab").inspect
