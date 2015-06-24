dictionary = ["bed", "bath", "and", "beyond"]
phrases = ["bedbathandbeyond", "bedbathandbeyon"]

def word_break_naive(phrase, dictionary)
    if phrase.size == 0
        return true
    else
        found = []
        dictionary.each { |word|
            if phrase.start_with?(word) 
                found << word_break_naive(phrase[word.size..-1], dictionary)
            end
        }
        
        return found.any? && found.reduce(:&)
    end
end

def word_break(phrase, dictionary)
    wb = Array.new(phrase.size + 1).map { false }
    
    0.upto(phrase.size).each { |i| 
        if !wb[i] && dictionary.include?(phrase[0..i - 1])
            puts phrase[0..i - 1]
            wb[i] = true
        end

        if wb[i]
            if i == phrase.size
                return true
            end
            
            (i + 1).upto(phrase.size).each { |j|
                if !wb[j] && dictionary.include?(phrase[i..j - 1])
                    puts phrase[i..j - 1]
                    wb[j] = true
                end

                if j == phrase.size && wb[j]
                    return true
                end
            }
        end
    }

    return false
end

phrases.each { |x|
    puts "#{x} - #{word_break_naive(x, dictionary)} - #{word_break(x, dictionary)}"
}
