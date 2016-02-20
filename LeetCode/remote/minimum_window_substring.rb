#   https://leetcode.com/problems/minimum-window-substring/
#    Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).
#
#    For example,
#    S = "ADOBECODEBANC"
#    T = "ABC"
#
#    Minimum window is "BANC". 
#   https://leetcode.com/submissions/detail/53978473/
#
#   Submission Details
#   266 / 266 test cases passed.
#       Status: Accepted
#       Runtime: 724 ms
#           
#           Submitted: 1 minute ago
#   This is a complete fucking mess.
#   3 hashtables and a lot of jerking around.. geez.
def min_window(s, t)
    targets = t.chars.reduce({}) { |acc, x| 
        acc[x] ||= 0
        acc[x] += 1
        acc
    }
    empties = targets.dup
    
    visited = {}
    left = 0
    max = ""
    for i in 0...s.size
        next if targets[s[i]].nil?
        visited[s[i]] = (visited[s[i]] || 0) + 1
        while (visited[s[left]].nil? || visited[s[left]] > targets[s[left]]) && left < i
            visited[s[left]] -= 1 if !visited[s[left]].nil?
            left += 1
        end
        
        if empties[s[i]]
            empties[s[i]] -= 1
            empties.delete(s[i]) if empties[s[i]] == 0
        end
        
        substring = s[left..i].to_s
        max = substring if (max == "" || substring.size < max.size) && empties.empty?
    end
    
    max
end
