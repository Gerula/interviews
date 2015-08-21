class String
    def cut(n)
        i = 0
        len = 0
        while i < self.size && i <= n
            if self[i] == " " || i == self.size - 1
                len = i
            end

            i += 1
        end

        return self[0, len]
    end
end

s = "would you like to get a bite to eat?"
0.upto(s.size - 1).each { |i|
    puts "#{s.cut(i)} #{i}"
}

