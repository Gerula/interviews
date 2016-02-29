#   https://leetcode.com/problems/letter-combinations-of-a-phone-number/
#
#   Given a digit string, return all possible letter combinations that the number could represent. 
#   https://leetcode.com/submissions/detail/54898669/
#
#   Submission Details
#   25 / 25 test cases passed.
#       Status: Accepted
#       Runtime: 76 ms
#           
#           Submitted: 0 minutes ago

@nums = { 1 => "", 2 => "abc", 3 => "def", 4 => "ghi", 5 => "jkl",
          6 => "mno", 7 => "pqrs", 8 => "tuv", 9 => "wxyz", 0 => "" }
          
def letter_combinations(digits)
    return [] if digits.to_s.empty?
    return @nums[digits.to_i].chars if digits.size == 1
    letter_combinations(digits[1..-1]).map { |right|
        @nums[digits.chars.first.to_i].chars.map { |digit|
            digit + right
        }
    }
    .flatten
end

def letter_combinations(digits)
    return [] if digits.to_s.empty?
    return @nums[digits.to_i].chars if digits.size == 1
    letter_combinations(digits[1..-1])
    .product(@nums[digits.chars.first.to_i].chars)
    .map { |x, y| 
        y + x
    }
end
