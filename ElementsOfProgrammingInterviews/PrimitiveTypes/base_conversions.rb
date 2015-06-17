class String
    def base_conversion(src, dest)
        x = self.chars.inject(0) { |acc, c|
            acc * src + c.ord - '0'.ord
        }
        
        result = ""
        while x > 0
            div, mod = x.divmod(dest)
            result = (mod + (mod < 10 ? '0'.ord : 'A'.ord - 10)).chr + result
            x = div
        end

        result
    end
end

puts [["255", 10, 16],
      ["111", 2, 10],
      ["111", 2, 16]].map{ |x| "#{x.inspect} - #{x[0].base_conversion(x[1], x[2])}" }
