require "test/unit"
extend Test::Unit::Assertions

class String
    def longest_valid_parenthesis
        stack = []
        last = -1
        max = 0
        self.chars.each_with_index { |c, i|
            if c == "("
                stack.push(i)
            else
                if stack.any?
                    stack.pop
                    max = [max, i - (stack.any? ? stack[-1] : last)].max
                else
                    last = i
                end
            end
        }

        return max 
    end
end

[[")()()(", 4], ["()", 2], ["))))",0]].each { |x|
    assert_equal(x[1], x[0].longest_valid_parenthesis)
}
