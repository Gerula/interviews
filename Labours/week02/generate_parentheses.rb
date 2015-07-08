class Fixnum
    def generate_parentheses(open, closed, results, result)
        if open == self && closed == self
            results << result.dup
        end

        len = result.size
        if open < self
            result << ["("]
            generate_parentheses(open + 1, closed, results, result)
        end

        if closed < open
            result << [")"]
            generate_parentheses(open, closed + 1, results, result)
        end

        (result.size - len).times {
            result.pop
        }
    end
end

results = []
3.generate_parentheses(0, 0, results, [])
puts results.map { |x| x.join("") }.inspect

