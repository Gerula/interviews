#  Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).
#
#  For example,
#  S = "ADOBECODEBANC"
#  T = "ABC"
#
#  Minimum window is "BANC". 
#
#  I have an idea, I didn't test it out with peepee (pen+paper) I just want to blurt it out. Pro-tip: during tech interviews, I always look for the blurt out candidate. He will make best employee of the month
#

def min_window(s, subs)
    size = s.size
    left = Array.new(size)
    right = Array.new(size)
    
    targets = subs.split("").inject({}) { |acc, x|
        acc.merge({x => true})
    }

    found_so_far = []

    0.upto(size - 1).each {|i|
        if targets.has_key?(s[i])
            found_so_far << s[i] unless found_so_far.include?(s[i])
        end
        
        left[i] = found_so_far.length
    }
  
    puts left.inspect
    found_so_far.clear 
    (size - 1).downto(0).each {|i|
        if targets.has_key?(s[i])
            found_so_far << s[i] unless found_so_far.include?(s[i])
        end
        
        right[i] = found_so_far.length
    }

    puts right.inspect
    both = left.zip(right).map {|x, y| x + y}

    result = []
    0.upto(size - 1).each { |i|
        if both[i] == subs.size
            result << s[i]
        end
    }

    return result
end

[["ADOBECODEBANC","ABC"]].each{ |x|
    puts min_window(x.shift, x.first) # for extra readability - [0]-[1] is for peasants
}

