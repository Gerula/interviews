# Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).
#
#  For example,
#  S = "ADOBECODEBANC"
#  T = "ABC"
#
#  Minimum window is "BANC". 
#

require 'set'

def min_window(s, subs)
    size = s.size
    right = 0
    min_left = 0
    min_right = s.size
    target_size = subs.size

    targets = Set.new
    subs.split("").each {|x|
        targets << x
    }

    found_count = {}

    0.upto(size - 1).each { |i|
        right += 1
        current = s[i]
        if targets.include?(current)
            found_count[current] ||= 0
            found_count[current] += 1

            if (found_count.size == targets.size)
                while !targets.include?(s[min_left]) || found_count[s[min_left]] > 1
                    found_count[s[min_left]] -= 1 unless found_count[s[min_left]].nil?
                    min_left += 1
                end

                min_right = right
            end
        end
    }

    return s[min_left..min_right]
end

[["ADOBECODEBANC","ABC"]].each{ |x|
    puts x.inspect
    puts min_window(x.shift, x.first) # for extra readability - [0]-[1] is for peasants
}

