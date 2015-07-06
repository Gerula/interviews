def sum(s, t)
    remainder = 0
    return s.chars.reverse.zip(t.chars.reverse).inject([]) { |agg, terms|
        remainder, digit = ((terms[0].nil? ? 0 : (terms[0].ord - '0'.ord)) +
                            (terms[1].nil? ? 0 : (terms[1].ord - '0'.ord)) +
                            remainder).divmod(10)
        agg.unshift((digit + '0'.ord).chr) 
    }.unshift(remainder != 0 ? remainder : nil).join('')
end

puts sum("423", "99")
