# http://careercup.com/question?id=5092414932910080
#
# Given a set of uniq chars and a string find the smallest
# substring containing all of them
#

require 'test/unit'
extend Test::Unit::Assertions

class String
    def uniques(c)
        hash = c.chars.inject({}) { |acc, x|
            acc[x] ||= 0
            acc
        }
        
        occurences = {}

        minstart = 0
        minlength = self.size
        left = 0
        (0...self.size).each { |i|
            current = self[i]
            if !hash[current].nil?
                occurences[current] ||= 0
                occurences[current] += 1
                hash[current] += 1

                if occurences.size != c.size
                    next
                end

                while left < i && 
                     (hash[self[left]].nil? ||
                      hash[self[left]] > 1)

                    hash[self[left]] -= 1 if !hash[self[left]].nil?
                    left += 1
                end

                distance = i - left + 1
                if distance < minlength 
                    minstart = left
                    minlength = distance
                end
            end
        }

        self[minstart, minlength]
    end
end

assert_equal("cba", "abbcbcba".uniques("abc"))
