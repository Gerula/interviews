#   https://leetcode.com/problems/excel-sheet-column-number/
#   https://leetcode.com/submissions/detail/54024927/

def title_to_number(s)
    s.chars.inject(0) { |acc, x| acc * 26 + (x.ord - 'A'.ord + 1) }
end
