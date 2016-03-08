#   https://leetcode.com/problems/maximum-product-of-word-lengths/
#    Given a string array words, find the maximum value of length(word[i]) * length(word[j]) where the two words do not share common letters.
#    You may assume that each word will contain only lower case letters. If no such two words exist, return 0.
#
#   TLE
def max_product(words)
    hash = words.inject({}) { |acc, x|
        acc[x] = x.chars.inject(0) { |num, c|
            num = num | (1 << (c[0].ord - 'A'.ord))
        } 
        acc
    }
    
    words
    .product(words)
    .select { |x, y| hash[x] & hash[y] == 0 }
    .map { |x, y| x.size * y.size }
    .max
end

