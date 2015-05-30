# Given an integer, convert it to a roman numeral.
#
# Input is guaranteed to be within the range from 1 to 3999.
#

class Fixnum
    $roman_map = {
                    1000 => "M",
                    900 => "CM",
                    500 => "D",
                    400 => "CD",
                    100 => "C",
                    90 => "XC",
                    50 => "L",
                    40 => "XL",
                    10 => "X",
                    9 => "IX",
                    5 => "V",
                    4 => "IV",
                    1 => "I"
                }
                    
    def to_roman
        n = self
        $roman_map.keys.inject("") { |acc, key|
            div, n = n.divmod(key)
            acc << $roman_map[key] * div
        }
    end
end

puts [1, 2, 3, 4, 10, 9, 30, 90, 100, 123].map { |x|
    x.to_roman
}.inspect
