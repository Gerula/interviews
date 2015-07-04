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
L = 16
n = words.size

def max_int 
    return 2 ** (0.size * 8 - 2)
end

def cost(words, page_size, i, j)
    width = (i == j) ? words[i].size : words[i..j].map{ |x| x.size + 1 }.reduce(:+) - 1
    if width <= page_size
        return (page_size - width) ** 3
    else
        return max_int 
    end
end

penalty = []
penalty[n] = 0
parent = []
parent[n] = nil

(n - 1).downto(0).each { |i|
    min = max_int 
    (i + 1).upto(n).each { |j|
        local_cost = penalty[j] + cost(words, L, i, j - 1) 
        if min >= local_cost
            min = local_cost
            parent[j] = i
        end
    }
    penalty[i] = min
}

next_word = parent[n]
while next_word
    puts words[next_word]
    next_word = parent[next_word]
end
