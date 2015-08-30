a = [1, 12, -5, -6, 50, 3]

class Result < Struct.new(:index, :max)
end

class Array
    def max_average(size)
        sum = 0
        window = []
        result = Result.new(-1, -2 ** (0.size * 8))
        self.each_with_index { |x, i|
            if window.size == size
                sum -= window.shift
            end 

            sum += x
            window.push(x)

            avg = sum.to_f / size
            if avg > result.min
                result.index = i - self.size
                result.max = avg
            end
        }

        return result
    end
end

puts a.max_average(4).inspect

