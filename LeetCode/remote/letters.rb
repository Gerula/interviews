# https://leetcode.com/submissions/detail/34036403/
# 84 ms

# @param {String} digits
# @return {String[]}
def letter_combinations(digits)
    result = []
    number_to_letters(digits, result, "")
    return result
end

def number_to_letters(digits, result, partial)
    if digits.empty?
        result << partial.dup unless partial.empty?
        return
    end
    
    digits(digits.chars.first).chars.each { |c|
        number_to_letters(digits[1..-1], result, partial + c)
    }
end

def digits(number)
    case number
        when "2"
        return "abc"
        when "3"
        return "def"
        when "4"
        return "ghi"
        when "5"
        return "jkl"
        when "6"
        return "mno"
        when "7"
        return "pqrs"
        when "8" 
        return "tuv"
        when "9"
        return "wxyz"
    else
        return ""
    end
end
