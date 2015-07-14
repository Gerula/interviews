def restore_ip_addresses(s)
    result = []
    split_ip(s, [], result)
    return result
end

def split_ip(string, partial, result)
    if partial.size == 4 && string.nil?
        result << partial.join(".")
        return
    end
    
    0.upto(3).each { |i|
        unless string.nil? || string.size < i
            n = string[0..i]
            if n.to_i <= 255
                partial << n
                split_ip(string[i+1..-1], partial, result)
                partial.pop
            end
        end
    }
end

puts restore_ip_addresses("25525511135").inspect

