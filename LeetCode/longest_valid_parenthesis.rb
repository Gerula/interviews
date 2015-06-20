class String
    def lvp
        stack = []
        last = 0
        max = 0
        0.upto(self.size - 1).each { |i|
            if self[i] == '('
                stack.push(i)
            else
                if !stack.any?
                    last = i
                else
                    stack.pop
                    max = stack.any?? [max, i - stack[-1]].max : [max, i - last].max
                end
            end
        }

        max
    end
end

[")()())", ")()"].each { |x|
    puts "#{x} - #{x.lvp}"
}
