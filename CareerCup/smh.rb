def gen(s, t, i)
    if i == s.size
        puts t
        return
    end

    if s[i] != "*"
        t[i] = s[i]
        gen(s, t, i + 1)
    else
        t[i] = "1"
        gen(s, t, i + 1)
        t[i] = "0"
        gen(s, t, i + 1)
    end
end

gen("1*010*1", "", 0)
