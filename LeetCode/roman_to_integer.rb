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
end

puts ["I", "IV", "V",  "XCVIII", "MDCCC", "LXXXVIII","XXXIX"].map{|x| {x => x.to_i_roman}}.inspect

