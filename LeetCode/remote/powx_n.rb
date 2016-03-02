#   https://leetcode.com/problems/powx-n/
#   Implement pow(x, n). 
#   https://leetcode.com/submissions/detail/55056349/
#
#   Submission Details
#   300 / 300 test cases passed.
#       Status: Accepted
#       Runtime: 72 ms
#           
#           Submitted: 0 minutes ago
def my_pow(x, n) 
    pow = pow_pow(x, n.abs)
    return pow if n >= 0
    return 1 / pow if n < 0
end

def pow_pow(x, n)
    return 1 if n == 0
    return x if n == 1
    return x * x if n == 2
    pow_pow(pow_pow(x, 2), n / 2) * (n % 2 == 0 ? 1 : x)
end
