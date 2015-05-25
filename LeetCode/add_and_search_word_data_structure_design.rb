#  Design a data structure that supports the following two operations:
#
#  void addWord(word)
#  bool search(word)
#
#  search(word) can search a literal word or a regular expression string containing only letters a-z or .. A . means it can represent any one letter.
#
#  For example:
#
#  addWord("bad")
#  addWord("dad")
#  addWord("mad")
#  search("pad") -> false
#  search("bad") -> true
#  search(".ad") -> true
#  search("b..") -> true
#
#  Note:
#  You may assume that all words are consist of lowercase letters a-z. 
#

class Letter < Struct.new(:value, :final)
end

class Record
    def initialize
        @data = {}
    end
    
    def addWord(word)
        current = @data
        word.chars.each_with_index { |letter,i|
            letter = Letter.new(letter, i == word.chars.length - 1)
            if current[letter].nil?
                current[letter] = {}
            end

            current = current[letter]
        }
    end

    def search(word)
        current = [@data]
        word.chars.select.with_index { |letter, i|
            letter = Letter.new(letter, i == word.chars.length - 1)
            found = current.find{ |x| !x[letter].nil?}
            if letter.value !='.' && found.nil?
                return false
            end
             
            if letter.value == '.'
                current = current.inject([]){ |acc, x|
                    acc | x.values
                }
            else
                current = [found[letter]]
            end
        }

       return true
    end
end

record = Record.new
record.addWord("bad")
record.addWord("bcd")
record.addWord("baddie")
record.addWord("mad")
record.addWord("dad")
puts record.inspect
["bad", "bc", "bcd", "bady", "b.d", "..d"].each { |x|
    puts "#{x} - #{record.search(x)}"
}
