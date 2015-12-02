# http://careercup.com/question?id=5640253559799808
#
# You know the result of a soccer match. Print all possible ways that
# the game ended up with that result.

def soccer(scores, score)
    puts scores.inspect if scores.last.first == score.first && scores.last.last == score.last
    soccer(scores << [scores.last.first + 1, scores.last.last], score) if scores.last.first < score.first
    soccer(scores << [scores.last.first, scores.last.last + 1], score) if scores.last.last < score.last
    scores.pop
end

soccer([[0, 0]], [1, 1])
soccer([[0, 0]], [2, 3])
