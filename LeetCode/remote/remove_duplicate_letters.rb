#   https://leetcode.com/problems/remove-duplicate-letters/
#
#   https://leetcode.com/submissions/detail/54027095/ very very slow

# @param {String} s
# @return {String}
def remove_duplicate_letters(s)
    return "" if s.to_s.empty?
    hash = s.chars.reduce({}) { |acc, c|
        acc[c] ||= 0
        acc[c] += 1
        acc
    }
    
    start = 0
    0.upto(s.size - 1).each { |i|
        start = i if s[i] < s[start]
        hash[s[i]] -= 1
        break if hash[s[i]] == 0
    }
    
    s[start] + remove_duplicate_letters((s[start + 1..-1] || "").gsub(s[start], ""))
end

#   https://leetcode.com/submissions/detail/55780403/
def remove_duplicate_letters(s)
    return "" if s.to_s.empty?
    counts = s.chars.reduce({}) { |acc, x|
        acc[x] ||= 0
        acc[x] += 1
        acc
    }
    
    idx = 0
    (0...s.size).each { |i|
        if s[i] < s[idx]
            idx = i
        end
        
        counts[s[i]] -= 1
        break if counts[s[i]] == 0
    }
    
    s[idx] + remove_duplicate_letters(s[idx  + 1..-1].gsub(s[idx], ""))
end
