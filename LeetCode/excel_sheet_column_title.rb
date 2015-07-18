# Excel Sheet Column Title Total Accepted: 30320 Total Submissions: 166508
#
# Given a positive integer, return its corresponding column title as appear in an Excel sheet.
# 
# For example:
# 
#     1 -> A
#     2 -> B
#     3 -> C
#     ...
#     26 -> Z
#     27 -> AA
#     28 -> AB 
#

def convert_to_title(n)
    result = []
    while n > 0
        n = n - 1
        div, mod = n.divmod(26)
        result.unshift((mod + 'A'.ord).chr)
        n = div
    end

    return result.join("")
end

1.upto(50).each { |x|
    print "[#{x} #{convert_to_title(x)}] "
}
puts

# 18 / 18 test cases passed.
#   Status: Accepted
#   Runtime: 68 ms
