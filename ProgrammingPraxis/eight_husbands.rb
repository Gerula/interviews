# https://www.reddit.com/r/dailyprogrammer/comments/3kj1v9/20150911_challenge_231_hard_eight_husbands_for/

require 'test/unit'
extend Test::Unit::Assertions

class Array
    def marry
        men = {}
        
        preferences = self.inject({}) { |acc, x|
            person = x.first
            acc[person] = [x[1..-1].each_with_index.inject({}) { |pref, k|
                pref[k.first] = k.last
                pref
            }, x[1..-1].reverse]

            if person == person.upcase
                men[person] = true
            end

            acc
        }
    
        matching = {}

        while men.any?
            man = men.first[0]
            perfect_woman = preferences[man].last.pop
            if matching[perfect_woman]
                current_man = matching[perfect_woman]
                if preferences[perfect_woman].first[current_man] > preferences[perfect_woman].first[man]
                    men[current_man] = true
                    matching[man] = perfect_woman
                    matching[perfect_woman] = man
                    men.delete(man)
                end
            else
                matching[man] = perfect_woman
                matching[perfect_woman] = man
                men.delete(man)
            end
        end

        return matching.inject([]) { |acc, x|
            acc << [x[0], x[1]] if x[0] == x[0].upcase
            acc
        }
    end
end

assert_equal([["A", "b"],
              ["B", "a"],
              ["C", "c"]],
               [["A", "b", "c", "a"],
                ["B", "b", "a", "c"],
                ["C", "c", "a", "b"],
                ["a", "C", "B", "A"],
                ["b", "A", "C", "B"],
                ["c", "A", "C", "B"]].marry)
