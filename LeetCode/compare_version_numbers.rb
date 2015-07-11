def larger?(a, b)
    first = a.split(".").map { |x| x.to_i }
    second = b.split(".").map { |x| x.to_i }
    while first.first == second.first && first.any? && second.any?
        first.shift
        second.shift
    end

    first = first.any? ? first.first : 0
    second = second.any? ? second.first : 0

    return first <=> second
end

puts ["0.1", "1.1", "1.2", "13.37"].each_cons(2).map { |a, b|
    larger?(a, b) ? "#{b}- #{a}" : "#{a} #{b}"
}.inspect
