# http://www.geeksforgeeks.org/given-a-string-print-all-possible-palindromic-partition/
# Given a string, find all possible palindromic partitions of given string.
#

require 'test/unit'
extend Test::Unit::Assertions

class String
    def partition
        result = []
        String.palindrome(self, 0, [], result)
        result
    end

    def self.palindrome(s, index, partial, result)
        if index == s.size
            result << partial.dup
            return
        end

        for i in 1..(s.size - index)
            candidate = s[index, i]
            if candidate == candidate.reverse 
                partial << candidate
                String.palindrome(s, index + i, partial, result)
                partial.pop
            end
        end
    end
end

assert_equal([
              ["n", "i", "t", "i", "n"],
              ["n", "iti", "n"],
              ["nitin"]
             ].sort, "nitin".partition.sort)

assert_equal([
              ["g", "e", "e", "k", "s"],
              ["g", "ee", "k", "s"]
             ].sort, "geeks".partition.sort)
