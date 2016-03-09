#   https://leetcode.com/problems/remove-duplicate-letters/
#
#   https://leetcode.com/submissions/detail/54027095/ very very slow

# @param {String} s
# @return {String}
def remove_duplicate_letters_1(s)
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
def remove_duplicate_letters_2(s)
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

#   https://leetcode.com/submissions/detail/55828173/
#
#   Submission Details
#   286 / 286 test cases passed.
#       Status: Accepted
#       Runtime: 208 ms
#           
#           Submitted: 0 minutes ago
#
def remove_duplicate_letters(s)
    last_occurrences = (0...s.size).reduce({}) { |acc, i|
        acc[s[i]] = i
        acc
    }
    
    result = ""
    last = 0
    while last_occurrences.any?
        min_occurrence = last_occurrences.min { |x, y| x.last <=> y.last }
        min_char = ('z'.ord + 1).chr
        (last..min_occurrence.last).each { |i|
            if s[i] < min_char && last_occurrences[s[i]]
                last = i + 1
                min_char = s[i]
            end
        }
        
        last_occurrences.delete(min_char)
        result += min_char
    end
    
    result
end

puts remove_duplicate_letters("cbacdcbc")
