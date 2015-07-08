def phone(number, keypad, result, step)
    if number.size == result.size
        puts result.join("")
        return
    end

    keypad[number[step].to_i].chars.each { |letter|
        phone(number, keypad, result + [letter], step + 1)
    }
end


phone("23", { 1 => "1", 2 => "abc", 3 => "def" }, [], 0)

                
