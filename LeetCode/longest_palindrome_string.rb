# Given a string S, find the longest palindromic substring in S. You may assume that the maximum length of S is 1000, and there exists one unique longest palindromic substring.
#

class String
    def longest_palindrome
        match = Array.new(self.size) do
                    Array.new(self.size) do
                        false
                    end
                end

        0.upto(self.size - 1) do |x|
            match[x][x] = true
        end

        start = 0;
        max_length = 1;
        
        for i in 0..self.size - 2 do
            if self[i] == self[i + 1]
                start = i
                max_length = 2
            end
        end

        for i in 3..self.size do
            for j in 0..self.size - i - 1 do
                k = i + j - 1
                if self[j] == self[k] && match[j + 1][k - 1]
                    match[j][k] = true

                    if k > max_length
                        max_length = k
                        start = j
                    end
                end
            end
        end

        return self[start, start + max_length]
    end
end

puts "cabcbaca".longest_palindrome
puts "banana".longest_palindrome
