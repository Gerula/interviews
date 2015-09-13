# https://leetcode.com/problems/add-digits/

def add_digits(num)
    while num.to_s.size != 1
        num = num.to_s.chars.map{|x| x.to_i }.reduce(:+)
    end

    return num
end

puts add_digits(38)
