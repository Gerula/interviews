def num_decodings(s)
    return s.nil? || s.empty? ? 
                1 :
                (s[0] == 0 ? 0 : num_decodings(s[1..-1])) + 
                (s.size > 1 && s[0, 2].to_i < 27 ? num_decodings(s[3..-1]) : 0)
end

class String
    #   
    #   Submission Details
    #   259 / 259 test cases passed.
    #       Status: Accepted
    #       Runtime: 84 ms
    #           
    #           Submitted: 0 minutes ago
    #
    #   https://leetcode.com/submissions/detail/51886086/
    #
    #   You are here!
    #   Your runtime beats 100.00% of ruby submissions.
    #
    #   YEah!! Really, there are probably like 2 other submissions...
    def num_decodings
        s = self
        return 0 if s.nil? || s.empty?
        dp = Array.new(s.size + 1)
        dp[s.size] = 1
        (s.size - 1).downto(0).each { |i|
            dp[i] = 0
            next if s[i] == '0'
            dp[i] = dp[i + 1] + (i < s.size - 1 && s[i, 2].to_i < 27 ? dp[i + 2] : 0)
        }

        dp[0]
    end

    #
    #   Submission Details
    #   259 / 259 test cases passed.
    #       Status: Accepted
    #       Runtime: 80 ms
    #           
    #           Submitted: 0 minutes ago
    #
    #   https://leetcode.com/submissions/detail/51890817/
    #
    #   You are here!
    #   Your runtime beats 100.00% of ruby submissions.
    def num_decode
        s = self
        return 0 if s.nil? || s.empty?
        dp = Array.new(s.size + 1)
        dp[0] = 1
        1.upto(s.size).each { |i|
            dp[i] = s[i - 1] == "0" ? 0 : dp[i - 1]
            dp[i] += i > 1 && s[i - 2] != "0" && s[i - 2, 2].to_i < 27 ? dp[i - 2] : 0
        }

        dp[s.size]
    end
end

puts num_decodings("12")
["10", "12"].each { |i|
    puts "#{i} #{i.num_decodings} #{i.num_decode}"
}
