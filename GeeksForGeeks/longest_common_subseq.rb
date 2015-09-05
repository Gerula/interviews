require 'test/unit'
extend Test::Unit::Assertions

def lcs_size(a, b)
    return 0 if a.empty? || b.empty?
    return 1 + lcs_size(a[0...-1], b[0...-1]) if a[-1] == b[-1]
    return [lcs_size(a[0...-1], b), lcs_size(a, b[0...-1])].max
end

assert_equal("ADH".size, lcs_size("ABCDGH", "AEDFHR"))
assert_equal("GTAB".size, lcs_size("AGGTAB", "GXTXAYB"))
