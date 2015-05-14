#  Write an efficient function that checks whether any permutation ↴ of an input string is a palindrome ↴ . 

def is_perm_palind?(string)
    array = string.split("")
    array.uniq.length <= array.length/2 + 1 
end

["12312", "11223", "1122334", "1122", "11542", "123"].each { |x|
    puts "#{x} - #{is_perm_palind?(x)}"
}

