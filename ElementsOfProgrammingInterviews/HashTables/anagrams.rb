class Array
    def anagrams
        return self.inject({}) { |agg, word|
            sorted = word.chars.sort.join("")
            agg[sorted] ||= []
            agg[sorted] << word
            agg
        }.values
    end
end

puts ["banana",
      "ananab",
      "ana",
      "naa",
      "ananab"].anagrams.inspect
