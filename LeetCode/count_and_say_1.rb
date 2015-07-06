def count_and_say(s)
    return '' if s.size == 0
    current = s[0]
    count = 1
    result = ""
    1.upto(s.size - 1).each { |i|
        if s[i] == current
            count += 1
        else
            result << "#{count}#{current}"
            current = s[i]
            count = 1
        end
    }

    result << "#{count}#{current}"
end

n = 4
puts 1.upto(n).inject(["1"]) { |acc, i|
    acc << count_and_say(acc.last)
}.inspect


