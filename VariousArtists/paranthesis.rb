# Write a function that, given a sentence like the one above, along with the position of an opening parenthesis, finds the corresponding closing parenthesis. 
#

def find_paranthesis(string, index)
    array = string.split("")
    stack = []
    (index + 1).upto(array.length - 1).each { |i|
        case array[i]
            when '('
                stack.push(i)
            when ')'
                if stack.any?
                    stack.pop
                else
                    return i
                end
        end
    }

    return -1
end

{
    "(123)"       => 0,
    "((((213))))" => 1,
    "(((213))))"  => 1,

}.each { |s, i|
    puts "#{s} pos #{i} match at #{find_paranthesis(s, i)}"
}
