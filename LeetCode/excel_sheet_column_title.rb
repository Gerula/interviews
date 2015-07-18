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
# 18 / 18 test cases passed.
# #   Status: Accepted
# #   Runtime: 68 ms

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

# Excel Sheet Column Number Total Accepted: 34118 Total Submissions: 93360
#
# Related to question Excel Sheet Column Title
#
# Given a column title as appear in an Excel sheet, return its corresponding column number.
#
# For example:
#
#     A -> 1
#     B -> 2
#     C -> 3
#       ...
#     Z -> 26
#     AA -> 27
#     AB -> 28
#
# 1000 / 1000 test cases passed.
# Status: Accepted
# Runtime: 108 ms
#           
# Submitted: 0 minutes ago 

def title_to_number(s)
    i = - 1
    s.chars.reverse.inject(0) { |agg, c|
        i += 1
        agg + 26 ** i * (c.ord - 'A'.ord + 1)
    }   
end

1.upto(50).each { |x|
    print "[#{x} #{convert_to_title(x)} #{title_to_number(convert_to_title(x))}] "
}
puts
