def missing_bits(a, result)
    if a.empty?
        puts "r"+result.inspect
        return
    end

    if a.first == "?"
        missing_bits(a[1..-1], result << 1)
        result.pop
        missing_bits(a[1..-1], result << 0)
    else
        missing_bits(a[1..-1], result << a.first)
    end 

    result.pop
end    

missing_bits([1, "?", 0, "?"],[])
