#   https://leetcode.com/problems/fraction-to-recurring-decimal/
#
#   Given two integers representing the numerator and denominator of a fraction, return the fraction in string format.
#
#   If the fractional part is repeating, enclose the repeating part in parentheses.

# This was a REAL fucking struggle. I kinda knew the solution but not really and a lot of corner cases which I basically ignored
#
# https://leetcode.com/submissions/detail/54036293/
# You are here!
# Your runtime beats 0.00% of rubysubmissions. Pfff
#   
#   Submission Details
#   35 / 35 test cases passed.
#       Status: Accepted
#       Runtime: 104 ms
#           
#           Submitted: 2 minutes ago

# @param {Integer} numerator
# @param {Integer} denominator
# @return {String}
def fraction_to_decimal(numerator, denominator)
    sign = (numerator < 0) == (denominator < 0) || numerator == 0 ? "" : "-"
    numerator = numerator.abs
    denominator = denominator.abs
    div, mod = numerator.divmod(denominator)
    return sign + div.to_s if mod == 0
    result = "#{sign}#{div}."
    hash = { mod => result.size }
    while mod != 0
        numerator = mod * 10
        div, mod = numerator.divmod(denominator)
        result += div.to_s
        if hash[mod].nil?
            hash[mod] = result.size
        else
            result = result[0, hash[mod]] + "(" + result[hash[mod]..-1] + ")"
            break
        end
    end
    
    return result[-1] == '.' ? result[0, result.size - 1] : result
end

