# Design an algorithm and write code to remove the duplicate characters in a string 
# without using any additional buffer. 
# NOTE: One or two additional variables are fine. An extra copy of the array is not.

$cache = []

def alreadyAdded?(string,length,character)
	if $cache.include?(character)
		return true
	elsif (0..length-1).any? {|x| string[x] == character}
		$cache.push(character)
		return true
	else
		return false
	end
end

def removeDupes(string)
	array = string.split("")
	write_point = 0
	read_point = 0
	count = 0
	cache = []
	while read_point < array.length
		if alreadyAdded?(array, write_point, array[read_point])
			read_point += 1
			count += 1
		else
			array[write_point] = array[read_point]
			write_point += 1
			read_point += 1
		end
	end
	count.times { array.pop }
	array.join
end

puts removeDupes("abbccf1cab")
