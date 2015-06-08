# Given an array of strings, return all groups of strings that are anagrams.
#
# Note: All inputs will be in lower-case.
#

class Array
    def anagrams
        self.inject({}) { |acc, x|
            key = x.chars.sort.join
            acc[key] ||= []
            acc[key] << x
            acc
        }
    end
end

puts ["abc", "bca", "cab", "123", "231", "234"].anagrams.values.inspect
