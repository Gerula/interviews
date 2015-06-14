# Valid palindrome one-liner
#

class String
    def palind?
        return self.chars.zip(self.chars.reverse).map{|a, b| a == b}.reduce(:&)
    end
end

["abcd", "ababa"].each { |x|
    puts "#{x} - #{x.palind?}"
}
