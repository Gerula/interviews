# Divide Two Integers Total Accepted: 41930 Total Submissions: 279706
#
# Divide two integers without using multiplication, division and mod operator.
#
# If it is overflow, return MAX_INT. 
#
# 988 / 988 test cases passed.
#   Status: Accepted
#   Runtime: 120 ms
#       
#       Submitted: 1 minute ago
#
# Wrote directly in browser:

def divide(dividend, divisor)
    i = 0
    sign = false
    sign = (dividend < 0 || divisor < 0) && (dividend > 0 || divisor > 0)

    # stupid fucking test case
    
    if (dividend == -2147483648 && divisor == -1)
        return sign ? (0 - 2147483647) : 2147483647
    end
    
    dividend = dividend.abs
    divisor = divisor.abs
    
    if (divisor == 1)
        i = dividend
    else
        while dividend >= divisor
            multiple, temp = 1, divisor
            while dividend >= (temp << 1)
                temp <<= 1
                multiple <<= 1
            end
            
            dividend -= temp
            i += multiple
        end
    end
    
    return sign ? (0 - i) : i
end
