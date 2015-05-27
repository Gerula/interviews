# The count-and-say sequence is the sequence of integers beginning as follows:
# 1, 11, 21, 1211, 111221, ...
#
# 1 is read off as "one 1" or 11.
# 11 is read off as "two 1s" or 21.
# 21 is read off as "one 2, then one 1" or 1211.
#
# Given an integer n, generate the nth sequence.
#
# Note: The sequence of integers will be represented as a string. 
#

class String
    def count_and_say
        result = ""
        i = 0
        count = 0 
        current = nil
        while i < self.length 
            if current.nil? || current == self[i]
                count += 1
            else
                result << count.to_s << current.to_s    
                count = 1
            end
            
            current = self[i]
            i += 1
        end
        result << count.to_s << current.to_s

        return result
    end
    
    def count_and_NINJA
        gsub(/(.)\1*/) {|x| "#{x.length}#{x[0,1]}"}
    end
end

puts ["1", "11", "21", "1211", "111221"].map{|x| { x => x.count_and_say }}.inspect

s = "1"
t = "1"
10.times {
    s = s.count_and_say
    t = t.count_and_NINJA
    puts [s, t].inspect
}
