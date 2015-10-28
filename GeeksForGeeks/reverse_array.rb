# http://www.geeksforgeeks.org/reverse-an-array-without-affecting-special-characters/
#
# Given a string, that contains special character together with alphabets (‘a’ to ‘z’ and ‘A’ to ‘Z’), reverse the string in a way that special characters are not affected.
#
# Examples:
#
# Input:   str = "a,b$c"
# Output:  str = "c,b$a"
# Note that $ and , are not moved anywhere.  
# Only subsequence "abc" is reversed
#
# Input:   str = "Ab,c,de!$"
# Output:  str = "ed,c,bA!$"
#

require 'test/unit'
extend Test::Unit::Assertions

class String
    def rev_sentence!
        self.rev!(false)        
        return self.
                split(" ").
                map{ |x| x.rev!(false) }.
                join(" ")
    end

    def rev!(specialchars)
        low = 0
        high = self.size - 1
        while low < high
            if !self[low].match(/^[[:alpha:]]$/) && specialchars
                low += 1
            elsif !self[high].match(/^[[:alpha:]]$/) && specialchars
                high -= 1
            else
                self[low], self[high] = self[high], self[low]
                low += 1
                high -= 1
            end
        end
        
        return self
    end
end

assert_equal("c,b$a", "a,b$c".rev!(true))
assert_equal("ed,c,bA!$", "Ab,c,de!$".rev!(true))
assert_equal("assert aequl somethin!!!g som@=else", "som@=else somethin!!!g aequl assert".rev_sentence!)

