# https://leetcode.com/submissions/detail/36701242/
#
# @param {String[]} strs
# @return {String}
def longest_common_prefix(strs)
    min_common = strs.map{ |x| x.nil? || x.empty? ? -1 : x.size }.min
    return nil if strs.nil?
    return "" if strs.empty? || min_common == -1
    for i in 0..min_common
        if !strs.map { |x| x[i] }.each_cons(2).inject(true){ |acc, x|
            acc &= x[0] == x[1]
        }
            return strs.first[0...i]
        end
    end

    return strs.first
end
