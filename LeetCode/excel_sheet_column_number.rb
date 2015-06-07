# Given a column title as appear in an Excel sheet, return its corresponding column number.
#
# For example:
#
#     A -> 1
#     B -> 2
#     C -> 3
#     ...
#     Z -> 26
#     AA -> 27
#     AB -> 28 
#

class String
    def column
        i = -1
        self.chars.reverse.inject(0) {|acc, c|
            i += 1
            acc + ("Z".ord - "A".ord + 1) ** i * (c.ord - "A".ord + 1)
        }
    end
end

["A", "AA", "AB", "Z", "B", "AB"].each { |x|
    puts "#{x} - #{x.column}"
}

