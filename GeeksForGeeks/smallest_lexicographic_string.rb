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
        self.chars.each_with_index { |c, i|
            accounting[c] ||= []
            accounting[c] << i
        }

        result = ""
        self.chars.each { |c|
            next if accounting[c].nil?
            if accounting[c].size == 1
                accounting[c] = nil
                result += c
                next
            end

            "a".upto(c).select{ |x| !accounting[x].nil? && x != c }.each { |k|
                if accounting[c].first < accounting[k].first
                    accounting[c].shift
                    break
                end
            }
        }

        result
    end
end

assert_equal("abc", "bcabc".dostuff)
assert_equal("acdb", "cbacdcbc".dostuff)
