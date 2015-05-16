#  Write a method to generate the nth Fibonacci number.
#

def fib(n)
    return 1 if n <= 2
    fib(n-1) + fib(n-2)
end

puts fib gets.chomp.to_i
