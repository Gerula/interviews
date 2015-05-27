# Given a roman numeral, convert it to an integer.
#
# Input is guaranteed to be within the range from 1 to 3999.
#

class Fixnum
    def self.roman_mapping
      {
          1000 => "M",
          900 => "CM",
          500 => "D",
          400 => "CD",
          100 => "C",
          90 => "XC",
          50 => "L",
          40 => "XL",
          10 => "X",
          9 => "IX",
          5 => "V",
          4 => "IV",
          1 => "I"
      }  
    end

    def to_roman
        num = self
        Fixnum.roman_mapping.inject("") { |acc, digits|
            digit, string = digits
            div, num = num.divmod(digit)
            acc << string * div 
        }
    end
end

class String
    def to_i_roman
        state = nil
        value = 0
        self.chars.each{ |input|
            current_value = Fixnum.roman_mapping.invert[state]
            input_value = Fixnum.roman_mapping.invert[input]
            if !current_value.nil? && current_value < input_value 
                value += input_value - 2 * current_value
            else
                value += input_value
            end
            state = input
        }

        return value
    end

    def to_i_roman_validate
        s = self.dup
        value = 0
        while !s.empty?
            pos = 1
            case 
            when s.start_with?("XXXX") then
                raise("too many Xs")
            when s.start_with?("IIII") then
                raise("too many Is")
            when s.start_with?("VV") then
                raise("too many Vs")
            when s.start_with?("CM") then
                value += 900
                pos = 2
            when s.start_with?("CD") then
                value += 400
                pos = 2
            when s.start_with?("XC") then
                value += 90
                pos = 2
            when s.start_with?("XL") then
                value += 40
                pos = 2
            when s.start_with?("IX") then
                value += 9
                pos = 2
            when s.start_with?("IV") then
                value += 4
                pos = 2
            when s.start_with?("M") then
                value += 1000
            when s.start_with?("D") then
                value += 500
            when s.start_with?("C") then
                value += 100
            when s.start_with?("L") then
                value += 50
            when s.start_with?("X") then
                value += 10
            when s.start_with?("V") then
                value += 5
            when s.start_with?("I") then 
                value += 1
            else 
                raise("Invalid numeral")
            end

            s = s[pos..-1]
        end

        return value
    end
end

puts ["I", "IV", "V",  "XCVIII", "MDCCC", "LXXXVIII","XXXIX"].map{|x| {x => [x.to_i_roman, x.to_i_roman_validate, x.to_i_roman.to_roman]}}.inspect

