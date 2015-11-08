# http://www.geeksforgeeks.org/check-if-a-given-number-is-fancy/
#
# A fancy number is one which when rotated 180 degrees is the same. Given a number, find whether it is fancy or not.

class Fixnum
    def fancy?
        map = { 1 => 1, 6 => 9, 9 => 6, 0 => 0 }
        return self.to_s == self.to_s.chars.reverse.map{ |x| map[x.to_i] }.join
    end
end

puts [96, 916, 996, 121].map { |x| "#{x} #{x.fancy? ? "" : "not"} fancy"}.inspect
