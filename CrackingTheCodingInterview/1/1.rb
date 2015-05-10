#Gyle says I need to pen and paper these. HA!
# I'll do it in Ruby for extra hipster points
#
# Implement an algorithm to determine if a string has all unique characters
# What if we're assholes and we don't let you use additional space?

def allUniqueHighSchoolStyle?(string)
	puts "Highschool!"
	puts "Does #{string} has all unique chars?"
	array = string.split("")
	(0..array.length-1).each do |x|
		(0..array.length-1).each do |y|
			if x!=y && array[x]==array[y]
				puts "At index #{x} and #{y} there is the same character #{array[x]}"
				return false
			end
		end
	end
	return true
end

def allUniqueHash?(string)
	puts "Hash"
	puts "Does #{string} has all unique chars?"
	hash = {}
	string.split("").each { |x|
	        hash[x]||=0	
		hash[x] = hash[x]+1
	}
	hash.values.any?{ |x| x > 1 }
end

puts allUniqueHash?("xyz")
puts allUniqueHash?("xxyz")
puts allUniqueHighSchoolStyle?("xyz")
puts allUniqueHighSchoolStyle?("xxyz")
