#   https://leetcode.com/problems/additive-number/
#   Additive number is a string whose digits can form additive sequence.
#
#   A valid additive sequence should contain at least three numbers. Except for the first two numbers,
#   each subsequent number in the sequence must be the sum of the preceding two.
#
#   For example:
#   "112358" is an additive number because the digits can form an additive sequence: 1, 1, 2, 3, 5, 8. 

def is_additive_number(num, parent = nil)
    return !parent.nil? if num.to_s.empty?
    if parent.nil?
        limit = 2 * num.size / 3
        (1...limit).each { |i|
            first = num[0...i].to_i
            (i..limit).each { |j|
                second = num[i..j].to_i
                next if second.to_s != num[i..j]
                sum = (first + second).to_s
                return true if num[j + 1..-1] == sum ||
                               num[j + 1..-1].start_with?(sum) &&
                               is_additive_number(num[j + 1..-1], second)
            }
        }

        return false
    else
        return (0...num.size)
        .map { |x|
            num[0..x].to_i
        }
        .select { |x|
            num[x.to_s.size..-1].start_with?((parent + x).to_s)
        }
        .map { |x|
            is_additive_number(num[x.size..-1], x)
        }
        .reduce(:|)
    end
end

[["", false],
 ["112358", true],
 ["123", true],
 ["1023", false],
 ["0235813", false],
 ["199100199", true]].each { |x, y|
    puts "#{x} #{y} #{is_additive_number(x)}"
}
