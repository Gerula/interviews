#  Write an efficient function that checks whether any permutation ↴ of an input string is a palindrome ↴ . 

def is_perm_palind?(string)
    frequencies = {}
    array = string.split("")

    array.each {|x|
        frequencies[x] ||= 0
        frequencies[x] += 1
    }

    if array.length % 2 == 0
        return frequencies.values.all? { |x| x % 2 == 0}
    else
        return frequencies.values.count { |x| x % 2 == 1} == 1
    end
end

["12312", "11223", "1122", "11542"].each { |x|
    puts "#{x} - #{is_perm_palind?(x)}"
}

