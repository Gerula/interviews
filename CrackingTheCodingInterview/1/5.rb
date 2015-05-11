#  Write a method to replace all spaces in a string with ‘%20’.

def escape_html(string)
    string.gsub(" ", "%20")
end

def escape_html_2(string)
    array = string.split("")
    num_spaces = array.count {|x| x == ' '}
    length = array.length
    new_length = length + num_spaces * 2
    write_iterator = new_length
    (length-1).downto(0) {|x|
        if array[x] == ' '
            array[write_iterator - 3], array[write_iterator - 2], array[write_iterator - 1] = ['%', '2', '0']
            write_iterator -= 3
        else
            array[write_iterator - 1] = array[x]
            write_iterator -= 1
        end
    }

    array.join
end

puts escape_html("Two old dudes are gay")
puts escape_html_2("Two old dudes are gay")
