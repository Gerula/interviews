require 'test/unit'
extend Test::Unit::Assertions

def lcs_size(a, b)
    return 0 if a.empty? || b.empty?
    return 1 + lcs_size(a[0...-1], b[0...-1]) if a[-1] == b[-1]
    return [lcs_size(a[0...-1], b), lcs_size(a, b[0...-1])].max
end

def lcs_size_2(a, b)
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
    
    return dp[a.size][b.size]
end

assert_equal("ADH".size, lcs_size("ABCDGH", "AEDFHR"))
assert_equal("GTAB".size, lcs_size("AGGTAB", "GXTXAYB"))
assert_equal("ADH".size, lcs_size_2("ABCDGH", "AEDFHR"))
assert_equal("GTAB".size, lcs_size_2("AGGTAB", "GXTXAYB"))
