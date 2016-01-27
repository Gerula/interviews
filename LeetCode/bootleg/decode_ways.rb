def num_decodings(s)
    return s.nil? || s.empty? ? 
                1 :
                (s[0] == 0 ? 0 : num_decodings(s[1..-1])) + 
                (s.size > 1 && s[0, 2].to_i < 27 ? num_decodings(s[3..-1]) : 0)
end

puts num_decodings("12")
