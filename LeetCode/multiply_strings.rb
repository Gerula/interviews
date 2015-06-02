# Given two numbers represented as strings, return multiplication of the numbers as a string.
#

class String
    def *(other)
        first = self.reverse
        other = other.reverse
        
        if first.size < other.size
            first, other = other, first
        end

        result = nil
        0.upto(other.size - 1).each { |j|
            partial_result = []
            remainder = 0
            val = 0
            0.upto(first.size - 1).each { |i|
                val, remainder = (other[j].to_i * first[i].to_i + val).divmod(10)
                partial_result << remainder
            }

            while val != 0
                val, remainder = val.divmod(10)
                partial_result << remainder
            end

            j.times {
                partial_result.unshift(0)
            }
            
            if result.nil?
                result = partial_result.dup
            else
                result << 0
                carry = 0
                div = 0
                result = result.zip(partial_result).map { |x|
                    div, mod = (x[0] + x[1] + carry).divmod(10)
                    carry = div
                    mod
                }

                while div != 0
                    val, carry = carry.divmod(10)
                    result << carry
                    carry = val
                end
            end
        }

        result.reverse.join
    end
end

puts ("1234" * "31").inspect
