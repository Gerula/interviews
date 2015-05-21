#  Given an array of words and a length L, format the text such that each line has exactly L characters and is fully (left and right) justified.
#
#  You should pack your words in a greedy approach; that is, pack as many words as you can in each line. Pad extra spaces ' ' when necessary so that each line has exactly L characters.
#
#  Extra spaces between words should be distributed as evenly as possible. If the number of spaces on a line do not divide evenly between words, the empty slots on the left will be assigned more spaces than the slots on the right.
#
#  For the last line of text, it should be left justified and no extra space is inserted between words. 
#
#

words = ["This", "is", "an", "example", "of", "text", "justification."]

def fully_justify(words, length)
    result = []
    it = 0
    while it < words.length
        greed = it
        size = 0
        partial = []
        while greed < words.length && size + words[greed].length + 1 < length
             size += words[greed].length + 1
             partial << words[greed]
             greed += 1
        end

        it = greed

        offset = false
        numspaces = (length < size)? 0 : length / size + length % size
        equity = numspaces / size 
        result.push( partial.reduce{ |acc, x|
            numspaces = numspaces - equity 
            acc<<" " * (numspaces + equity)<<x
        })
    end

    return result
end

puts fully_justify(words, 16).inspect
