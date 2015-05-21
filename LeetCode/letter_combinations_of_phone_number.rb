# Given a digit string, return all possible letter combinations that the number could represent. 
#
# Input:Digit string "23"
# Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].
#

keypad = {1 => "1", 2 => "abc", 3 => "def", 4 => "ghi", 5 => "jkl", 6 => "mno", 7 => "pqrs", 8 => "stuv", 9 => "wxyz"}

def print_combinations(keypad, keys, result)
    if !keys.any?
        puts result.inspect
        return
    end
    
    keypad[keys.first].split("").each { |key|
        print_combinations(keypad, keys[1..-1], [result,key].flatten)
    }
end

[[1, 2, 3], [4, 2, 5], [2, 3]].each {|x|
    puts x.inspect
    print_combinations(keypad, x, [])
}
