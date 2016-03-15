#   https://leetcode.com/problems/excel-sheet-column-title/
#   Given a positive integer, return its corresponding column title as appear in an Excel sheet.
#   https://leetcode.com/submissions/detail/56369979/
#
#   Submission Details
#   18 / 18 test cases passed.
#       Status: Accepted
#       Runtime: 72 ms
#           
#           Submitted: 0 minutes ago
def convert_to_title(n)
    result = ""
    while n > 0
        n -= 1
        div, mod = n.divmod(26)
        result = ("A".ord + mod).chr + result
        n = div
    end
    
    result
end
