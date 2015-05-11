# Write a method to decide if two strings are anagrams or not.

def anagrams?(first, second)
    puts "Are #{first} and #{second} anagrams?"
    first.split("").sort == second.split("").sort
end

def anagrams_any?(first, second)
    puts "Are #{first} and #{second} anagrams?"
    first.split("").all? {|x| second.include?(x)} &&
    second.split("").all? {|x| first.include?(x)} 
end    

puts anagrams?("abcd", "bcda")
puts anagrams?("abc", "bc")
puts anagrams?("12345", "54321")
puts anagrams?("", "23")
puts anagrams_any?("abcd", "bcda")
puts anagrams_any?("abc", "bc")
puts anagrams_any?("12345", "54321")
puts anagrams_any?("", "23")

