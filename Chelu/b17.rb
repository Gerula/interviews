#  Convert a string to a long. 
#

class String
    def atoi
        self.chars.inject(0) { |acc, c|
            acc * 10 + c.to_i
        }
    end
end

["12345", "335", "0"].each { |x|
    puts x.atoi
}
