# Write a function to find the longest common prefix string amongst an array of strings. 
#
# Some say trie, I say fuck them
#

class Array
    def lcp
        length = 0
        while self.map{ |x| x[length]}.each_cons(2).map{ |a, b| a == b }.reduce(:&)
            length += 1
        end

        return self[0][0..length + 1]    
    end
end

puts [["banana"],
     ["bananarama"],
     ["bananainmouth"],
     ["bananainyourmomma"],
     ["bananamonkey"],
     ["bananahahaa"]].lcp
