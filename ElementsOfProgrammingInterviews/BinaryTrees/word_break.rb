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

phrases.each { |x|
    puts "#{x} - #{word_break_naive(x, dictionary)}"
}
