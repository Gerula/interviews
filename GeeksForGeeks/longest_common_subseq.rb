require 'test/unit'
extend Test::Unit::Assertions

def lcs_size(a, b)
    return 0 if a.empty? || b.empty?
    return 1 + lcs_size(a[0...-1], b[0...-1]) if a[-1] == b[-1]
    return [lcs_size(a[0...-1], b), lcs_size(a, b[0...-1])].max
end

def lcs(a, b)
    dp = Array.new(a.size + 1) {
        Array.new(b.size + 1) {
            0
        }
    }

    for i in 0..a.size
        for j in 0..b.size
            if i == 0 || j == 0
                dp[i][j] = 0
            elsif a[i - 1] == b[j - 1]
                dp[i][j] = 1 + dp[i - 1][j - 1]
            else
                dp[i][j] = [dp[i - 1][j], dp[i][j - 1]].max
            end
        end
    end
    
    i, j = a.size, b.size
    size = dp[i][j]
    result = Array.new(size)
    while i > 0 && j > 0
        if a[i - 1] == b[j - 1]
            result[size - 1] = a[i - 1]
            size -= 1
            i -= 1
            j -= 1
        else
            if dp[i - 1][j] > dp[i][j - 1]
                i -= 1
            else
                j -= 1
            end
        end
    end

    return result.join
end

assert_equal("ADH".size, lcs_size("ABCDGH", "AEDFHR"))
assert_equal("GTAB".size, lcs_size("AGGTAB", "GXTXAYB"))
assert_equal("ADH", lcs("ABCDGH", "AEDFHR"))
assert_equal("GTAB", lcs("AGGTAB", "GXTXAYB"))
