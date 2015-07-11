class Fixnum
    def power_of_two? 
        return self & (self - 1) == 0
    end
end

puts 1.upto(1000000).select{ |x| x.power_of_two? }.inspect
