#  Given an integer between 0 and 999,999, print an English phrase that describes the integer (eg, “One Thousand, Two Hundred and Thirty Four”).
#

translation = {1 => "One", 2 => "Two", 3 => "Three", 4 => "Four", 5 => "Five", 6 => "Six", 7 => "Seven", 8 => "Eight", 9 => "Nine",
10 => "Ten", 11 => "Eleven", 20 => "Twenty", 30 => "Thirty", 100 => "Hundred", 1000 => "Thousand"}

n = 1234

[1000, 100, 10].each { |x|
    print "#{translation[n / x]} #{translation[(n - n % x) / (n / x)]} "
    n = n % x
}

print "#{translation[n]}"
puts
