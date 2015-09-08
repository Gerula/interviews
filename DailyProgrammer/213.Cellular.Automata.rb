# https://www.reddit.com/r/dailyprogrammer/comments/3jz8tt/20150907_challenge_213_easy_cellular_automata/
#

class String
    def rule_90(steps)
        result = [self.chars.map { |x| x == "1" ? "x" : " "}.join]
        steps.times { 
            last = result.last
            current = last.chars.each_cons(3).inject("") { |acc, x|
                        acc += x[0] != x[2] ? "x" : " "
                        acc
                      }
            current = (last[1] == "x" ? "x" : " ") + current
            current += last[last.size - 2] == "x" ? "x" : " "
            result << current
            break if current.chars.all?{ |x| x == " "}
        }

        return result.join("\n")
    end
end

puts "1101010".rule_90(25)
puts "00000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000".rule_90(100)

