# https://leetcode.com/submissions/detail/34510940/

# @param {String} input
# @return {Integer[]}
def diff_ways_to_compute(input)
    result = []
    for i in 0..input.size-1
        if input[i] == '*' || input[i] == '-' || input[i] == '+'
            left = diff_ways_to_compute(input[0...i])
            right = diff_ways_to_compute(input[i+1..-1])
            left.product(right).each { |x|
                case input[i]
                    when '*'
                        result << x[0] * x[1]
                    when '-'
                        result << x[0] - x[1]
                    when '+'
                        result << x[0] + x[1]
                end
            }
        end
    end
    
    if result.empty?
        result << input.to_i
    end
    
    return result
end

