# Given two strings s and t, determine if they are isomorphic.
#
# two strings are isomorphic if the characters in s can be replaced to get t.

Def isomorphic?(s, t)
    a_s = s.split("")
    a_t = t.split("")
    a_s.map{|x| a_s.index(x)} == a_t.map{|x| a_t.index(x)}
end

puts isomorphic?("egg", "add")
puts isomorphic?("foo", "bar")
puts isomorphic?("paper", "title")
