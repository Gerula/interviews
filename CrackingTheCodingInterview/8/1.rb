#  Write a method to generate the nth Fibonacci number.
#

def fib(n)
    return 1 if n <= 2
    fib(n-1) + fib(n-2)
end

def fib_iterative(n)
    prev = 1
    prev_prev = 1
    current = 0

    (n-2).times {
        current = prev + prev_prev
        prev_prev = prev
        prev = current
    }

    current
end

def multiply(a, b)
    return [[a[0][0] * b[0][0] + a[0][1] * b[1][0], a[0][0] * b[0][1] + a[0][1] * b[1][1]], [a[1][0] * b[0][0] + a[1][1] * b[1][0], a[1][0] * b[0][1] + a[1][1] * b[1][1]]]
end

def fast_power(a, power)
    return a if power < 2
    return multiply(a, a) if power == 2 

    if power % 2 == 0
        return fast_power(fast_power(a, 2), power / 2)
    else
        return multiply(a, fast_power(fast_power(a, 2), (power - 1) /2)) 
    end
end

def fib_matrix(n)
    return fast_power([[1, 1],[1, 0]], n - 1)[0][0]
end

puts fib_matrix(gets.chomp.to_i)
