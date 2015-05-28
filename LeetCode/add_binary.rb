# Add Binary
#  Given two binary strings, return their sum (also a binary string).
#
#  For example,
#  a = "11"
#  b = "1"
#  Return "100". 
#

a = "11"
b = "1"

array = a.chars.reverse.zip(b.chars.reverse)

remainder = 0
array.map! { |x|
    remainder, sum = (x[0].to_i + x[1].to_i + remainder).divmod(2)
    sum
}

if remainder != 0
    array.unshift(remainder)
end

puts array.join("")
