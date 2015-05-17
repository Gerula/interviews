#  Write a method to compute all permutations of a string.

def perms(s, current)
    if s.length == current
        puts s.join()
    else
        (0..s.length-1).each do |i|
            s[i], s[current] = s[current], s[i]
            perms(s, current + 1)
            s[i], s[current] = s[current], s[i]
        end
    end
end

perms("12345".split(""), 0)
