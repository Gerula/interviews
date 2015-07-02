a = [3, 30, 34, 5, 9]

class Array
    def largest_number
        result = self.sort!{|a, b| (b.to_s + a.to_s).to_i <=> (a.to_s + b.to_s).to_i}.join("").sub(/^[0:]*/,"")
        return result.chars.any? ? result : "0"
    end
end

puts a.largest_number
