value = :stuff

string = "I like stuff"
other = "stuff is what i like"

puts value.hash
puts :stuff.hash

puts other.start_with?(value.to_s)
puts string.include?(value.to_s)
sym = "stuff"
puts sym.to_sym.hash
