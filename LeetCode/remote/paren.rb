# https://leetcode.com/submissions/detail/34037473/

# @param {Integer} n
# @return {String[]}
def generate_parenthesis(n)
    result = []
    gen(n, 0, 0, result, "")
    return result
end

def gen(n, left, right, result, partial)
    if left == n && right == n
        result << partial.dup
    end
    
    if left < n
        gen(n, left + 1, right, result, partial + "(")
    end
    
    if right < left
        gen(n, left, right + 1, result, partial + ")")
    end
end
