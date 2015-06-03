# Write a string-replace function with linear complexity
#

class String
    def replace_n(pattern, replacement)
        output = []
        input = self.chars
        window = []
        pattern = pattern.chars
        replacement = replacement.chars
        0.upto(input.size - 1).each {|i|
            if window.size ==  pattern.size
                window.shift
            end
            output << input[i]
            window << input[i]
            if window.hash == pattern.hash
                output = (output.size == window.size)? [] : output[0..output.size - 1 - window.size]
                output = output + replacement
                window.clear
            end
        }
        return output.join
    end
end

["abcdef", "abbcdef", "dabc"].each { |x|
    puts "#{x} = #{x.replace_n("abc", "***")}"
}
