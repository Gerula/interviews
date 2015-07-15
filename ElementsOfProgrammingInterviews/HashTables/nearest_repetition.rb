class Array
    def nearest_repetition
        return self.each_with_index.inject({}) { |acc, word|
            if acc[word[0]] 
                acc[word[0]][1] = word[1] - acc[word[0]][0]
                acc[word[0]][0] = word[1]
            else
                acc[word[0]] = [word[1], nil]
            end
            acc
        }.map { |x, v| v[1] ? [x, v[1]] : nil }.compact.min { |w, y| w[1] <=> y[1] }
    end
end

puts ["All", "work", "and", "no", "play", "makes", "for", "no", "work", "no", "fun", "and", "no", "results"].nearest_repetition.inspect
