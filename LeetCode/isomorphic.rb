def iso?(s, t)
   return s.chars.map { |x| s.chars.index(x)} == t.chars.map { |x| t.chars.index(x)}
end

[["egg", "add"],
 ["foo", "bar"],
 ["paper", "title"]].each { |x|
    puts "#{x.inspect} #{iso?(x[0], x[1])}"
}
