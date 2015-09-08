# https://www.reddit.com/r/dailyprogrammer/comments/3jz8tt/20150907_challenge_213_easy_cellular_automata/
#

class String
    def xor(other)
        self != other ? "x" : " "
    end

    def rule_90(steps)
        result = [self.chars.map { |x| x == "1" ? "x" : " "}.join]
        steps.times { 
            result << (" " + result.last + " ").chars.each_cons(3).inject("") { |acc, x|
                        acc += x[0].xor(x[2])
                      }
            break if result.last.chars.all?{ |x| x == " "}
        }

        return result.join("\n")
    end
end

puts "1101010".rule_90(25)
puts "00000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000".rule_90(100)

