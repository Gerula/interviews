# Given a string which only contains lowercase. You need delete the repeated letters only leave one, and try to make the lexicographical order of new string is smallest. 
# i.e: 
# bcabc 
# You need delete 1 'b' and 1 'c', so you delete the first 'b' and first 'c', the new string will be abc which is smallest. 
# PS: If you try to use greedy algorithm to solve this problem, you must make sure that you could pass this case: ​
# cbacdcbc. answer is acdb not adcb.

require 'test/unit'
extend Test::Unit::Assertions

class String
    def dostuff
        accounting = {}
        (self.size - 1).downto(0).each { |i|
            if accounting[self[i]].nil?
                accounting[self[i]] = i
            else
                if self[i] < self[i + 1] && accounting[self[i + 1]] == i + 1
                    accounting[self[i]] = i
                end
            end
        }
        
        accounting = accounting.invert
        0.upto(self.size - 1).select{ |i| accounting[i] }.map { |x| self[x] }.join
    end
end

assert_equal("abc", "bcabc".dostuff)
assert_equal("acdb", "cbacdcbc".dostuff)
