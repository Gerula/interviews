#   https://leetcode.com/problems/repeated-dna-sequences/
#
#    All DNA is composed of a series of nucleotides abbreviated as A, C, G, and T, for example: "ACGAATTCCG".
#    When studying DNA, it is sometimes useful to identify repeated sequences within the DNA.
#
#    Write a function to find all the 10-letter-long sequences (substrings) that occur more than once in a DNA molecule.
#   https://leetcode.com/submissions/detail/54015774/
#
#   Submission Details
#   30 / 30 test cases passed.
#       Status: Accepted
#       Runtime: 216 ms
#           
#           Submitted: 0 minutes ago
# You are here!
# Your runtime beats 100.00% of rubysubmissions.

@map = { 'A' => 1, 'C' => 2, 'G' => 3, 'T' => 4 }

def find_repeated_dna_sequences(s)
    size = 10
    factor = size ** 10
    hash = {}
    num = 0
    result = {}
    for i in 0...s.size
        num = num * 10 + @map[s[i]]
        next if i < 9
        num = num % factor
        result[s[i - size + 1, size]] = true if !hash[num].nil?
        hash[num] = true
    end
    
    result.keys
end

