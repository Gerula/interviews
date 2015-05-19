a = [1, 2, 3, 4, 5, 6, 7, 8]
b = [3, 4, 5, 10, 11]

def merge(a, b)
    result = []
    while a.any? && b.any?
        result.push(a.first > b.first ? b.shift : a.shift)
    end

    result + a + b
end

puts merge(a, b).inspect
