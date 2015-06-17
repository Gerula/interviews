class Array
    def encode
        self.inject("") { |acc, x|
            n = x
            binary = ""
            bits = 0
            while n > 0
                bits += 1
                div, mod = n.divmod(2)
                binary = mod.to_s + binary
                n = div
            end

            acc + "0" * (bits - 1) + binary
        }
    end
end

class String
    def decode
        result = []
        filler = true
        partial = ""
        i = 0
        count = 0
        while i < self.size
            if filler 
               if self[i] == '0'
                   count += 1
                   i += 1
               else
                   filler = false
               end
            else
                partial = partial + self[i]
                i += 1
                if count == 0
                    result << partial.chars.inject(0) { |acc, c|
                        acc * 2 + c.to_i
                    }
                    filler = true
                    partial = ""
                else
                    count -= 1
                end
            end
        end 

        result
    end
end

puts [1, 2, 3, 4, 5, 6, 7, 8, 9, 10].encode
puts [1, 2, 3, 4, 5, 6, 7, 8, 9, 10].encode.decode.inspect
