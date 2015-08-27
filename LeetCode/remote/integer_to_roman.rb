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

assert_equal("V", int_to_roman(5))
assert_equal("MCMLIV", int_to_roman(1954))
assert_equal("MCMXC", int_to_roman(1990))
assert_equal("MMXIV", int_to_roman(2014))
assert_equal("MMMCMXCIX", int_to_roman(3999))
