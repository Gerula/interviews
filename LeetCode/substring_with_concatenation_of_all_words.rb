#  You are given a string, s, and a list of words, words, that are all of the same length. Find all starting indices of substring(s) in s that is a concatenation of each word in words exactly once and without any intervening characters.
#
#  For example, given:
#  s: "barfoothefoobarman"
#  words: ["foo", "bar"]
#
#  You should return the indices: [0,9].
#  (order does not matter). 
#

class String
    def substring(words)
        hash = words.map { |x| x.chars }.flatten.map { |x| x.ord }.reduce(:+)
        size = words.map { |x| x.size }.reduce(:+) 
        roll = self[0...size].chars.map { |x| x.ord }.reduce(:+)
        result = []
        for i in size..self.size - 1
            if roll == hash
                if self.word_match?(i - size, size, words)
                    result << (i - size == 0 ? i - size : i - size - 1)
                end
            end

            roll -= self[i - size].ord
            roll += self[i].ord
        end

        result
    end

    def word_match?(position, size, words)
        return words.all? { |x| self[position, size].include?(x) }
    end
end

puts "barfootherfoobarman".substring(["foo", "bar"]).inspect

