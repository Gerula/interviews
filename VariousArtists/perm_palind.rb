#  Write an efficient function that checks whether any permutation ↴ of an input string is a palindrome ↴ . 

def is_perm_palind?(string)
    uniques = []
    array = string.split("")

    array.each {|x|
        if !uniques.include?(x)
            uniques.push(x)
        end
    }

    uniques.length <= array.length/2 + 1 
end

["12312", "11223", "1122334", "1122", "11542", "123"].each { |x|
    puts "#{x} - #{is_perm_palind?(x)}"
}

