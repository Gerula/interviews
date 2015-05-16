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

puts fib_iterative gets.chomp.to_i
