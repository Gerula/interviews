require 'test/unit'
extend Test::Unit::Assertions

class String
    def partition
        palindrome = Array.new(self.size + 1) {
            Array.new(self.size + 1) {
                false
            }
        }

        min_cut = 0.upto(self.size).map { |i| i - 1 }
        prev = []

        2.upto(self.size).each { |i|
            (i - 1).downto(0).each { |j|
                if self[i - 1] == self[j] && (i - 1 - j < 2 || palindrome[j + 1][i - 1])
                    palindrome[j][i] = true
                    if min_cut[j] + 1 < min_cut[i]
                        min_cut[i] = min_cut[j] + 1
                        prev[i] = j
                    end
                end
            }
        }

        prev.push(self.size)

        return prev.compact.each_cons(2).map{ |x, y| self[x...y] }
    end
end

assert_equal(["aa", "b"], "aab".partition)
