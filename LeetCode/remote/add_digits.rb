# https://leetcode.com/problems/add-digits/

def add_digits(num)
    while num.to_s.size != 1
        num = num.to_s.chars.map{|x| x.to_i }.reduce(:+)
    end

    return num
end

def add_digits_2(num)
    return 0 if num == 0
    return 9 if num % 9 == 0
    return eum % 9
end

puts add_digits(38)
puts add_digits_2(38)

