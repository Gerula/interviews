# Write code to reverse a C-Style String. (C-String means that “abcd” is represented as five characters, including the null character.)
#

string = ['a','b','c','d',nil]

start_idx = 0
end_idx = string.length - 2

while start_idx < end_idx
	aux = string[start_idx]
	string[start_idx] = string[end_idx]
	string[end_idx] = aux
        start_idx += 1
	end_idx -= 1	
end

puts string.join

string = ['a', 'b', 'c', 'd', nil]
string.reverse!
string.push(string[0])
string.drop(1)
puts string.join
