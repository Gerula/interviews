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

class Fixnum
    def column
        x = self
        result = ""
        offset = "Z".ord - "A".ord + 1
        first = "A".ord 
        while x > 0
            div, mod = x.divmod(offset)
            x = div - ((mod == 0)? 1 : 0)
            result = (mod == 0)? "Z" + result : (first + mod - 1).chr + result
        end
        result
    end
end

["A", "AA", "AB", "Z", "B", "AB"].each { |x|
    puts "#{x} - #{x.column}"
}

[27, 28, 26, 2, 4].each { |x|
    puts "#{x} - #{x.column}"
}
