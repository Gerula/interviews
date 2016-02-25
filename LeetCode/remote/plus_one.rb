#   https://leetcode.com/problems/plus-one/
#   Given a non-negative number represented as an array of digits, plus one to the number.
#   https://leetcode.com/submissions/detail/54458870/

# @param {Integer[]} digits
# @return {Integer[]}
def plus_one(digits)
    remainder = 1
    (digits.size - 1).downto(0).each { |i|
        digits[i] += remainder
        remainder = digits[i] / 10
        digits[i] %= 10
    }
    
    digits.unshift(remainder) if remainder != 0
    return digits
end
