# Given an integer, convert it to a roman numeral.
#
# Input is guaranteed to be within the range from 1 to 3999.
# https://leetcode.com/submissions/detail/37733643/
#
# 3999 / 3999 test cases passed.
#   Status: Accepted
#   Runtime: 216 ms
#       
#       Submitted: 0 minutes ago
#

require 'test/unit'
extend Test::Unit::Assertions

def int_to_roman(num)
    romans = {1000 => "M", 
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
                 1 => "I"}

    return romans.keys.inject("") { |acc, c|
        while num >= c
            acc += romans[c]
            num -= c
        end

        acc
    }
end

# https://leetcode.com/submissions/detail/37734695/
#
# 3999 / 3999 test cases passed.
#   Status: Accepted
#   Runtime: 168 ms
#       
#       Submitted: 0 minutes ago
#
# You are here!
# Your runtime beats 100.00% of ruby coders. <- sure looks ugly but it's fucking fast!
#
#

def int_to_roman_2(num)
    result = ""
    while num > 0
        if num >= 1000
            num -= 1000
            result += "M"
        elsif num >= 900
            num -= 900
            result += "CM"
        elsif num >= 500
            num -= 500
            result += "D"
        elsif num >= 400
            num -= 400
            result += "CD"
        elsif num >= 100
            num -= 100
            result += "C"
        elsif num >= 90
            num -= 90
            result += "XC"
        elsif num >= 50
            num -= 50
            result += "L"
        elsif num >= 40
            num -= 40
            result += "XL"
        elsif num >= 10
            num -= 10
            result += "X"
        elsif num >= 9
            num -= 9
            result += "IX"
        elsif num >= 5
            num -= 5
            result += "V"
        elsif num >= 4
            num -= 4
            result += "IV"
        else
            num -= 1
            result += "I"
        end
    end

    return result
end

assert_equal("V", int_to_roman(5))
assert_equal("MCMLIV", int_to_roman(1954))
assert_equal("MCMXC", int_to_roman(1990))
assert_equal("MMXIV", int_to_roman(2014))
assert_equal("MMMCMXCIX", int_to_roman(3999))
assert_equal("V", int_to_roman_2(5))
assert_equal("MCMLIV", int_to_roman_2(1954))
assert_equal("MCMXC", int_to_roman_2(1990))
assert_equal("MMXIV", int_to_roman_2(2014))
assert_equal("MMMCMXCIX", int_to_roman_2(3999))
