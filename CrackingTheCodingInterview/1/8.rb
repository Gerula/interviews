#  Assume you have a method isSubstring which checks if one word is a substring of another. Given two strings, s1 and s2, write code to check if s2 is a rotation of s1 using only one call to isSubstring (i.e., “waterbottle” is a rotation of “erbottlewat”).
#

def is_substring?(string, substring)
    string.include?(substring)
end

def is_rotation?(string, rotated)
    (string + string).include?(rotated) && string.length == rotated.length
end

puts is_rotation?("Two gay dudes on TV", "s on TVTwo gay dude")
puts is_rotation?("Two gay dudes on TV", "on TVTwo gay dude")
