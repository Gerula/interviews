#  Find the duplicate elements in a string. 

s = "ab123cdaaaadb"

puts s.chars.inject({}){ |acc, c| 
    acc[c] ||= 0 
    acc[c] += 1
    acc
}.select {|x, y|
    y>=2
}.keys.inspect
