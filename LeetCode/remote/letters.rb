# https://leetcode.com/submissions/detail/34036403/
# 84 ms

# https://leetcode.com/submissions/detail/34036943/
# 68 ms

# @param {String} digits
# @return {String[]}
def letter_combinations(digits)
    result = []
    number_to_letters(digits.chars, 0 , result, [])
    return result
end

def number_to_letters(digits, step, result, partial)
    if step == digits.size
        result << partial.join("") unless partial.empty?
        return
    end
    
    digits(digits[step]).each { |c|
        partial[step] = c
        number_to_letters(digits, step + 1, result, partial)
    }
end

def digits(number)
    case number
        when "2"
        return ["a", "b", "c"]
        when "3"
        return ["d", "e", "f"]
        when "4"
        return ["g", "h", "i"]
        when "5"
        return ["j", "k", "l"]
        when "6"
        return ["m", "n", "o"]
        when "7"
        return ["p", "q", "r", "s"]
        when "8" 
        return ["t", "u", "v"]
        when "9"
        return ["w", "x", "y", "z"]
    else
        return ""
    end
end
