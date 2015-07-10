class Fixnum
    def gray_code
        2.upto(self).inject([0, 1]) { |agg, x|
            down = agg.map { |x| [0, x].flatten }
            up = agg.reverse.map { |x| [1, x].flatten }
            agg = down + up
        }.map { |x|
            x.reverse.map.with_index { |bit, power|
                bit * 2 ** power
            }.reduce(:+)
        }
    end
end

puts 3.gray_code.inspect
