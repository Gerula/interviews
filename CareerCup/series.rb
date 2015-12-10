#   http://careercup.com/question?id=5744076173344768
#
#   Write a program to display the series 1,2,6,15,31,56,......,N

#   1 4 9 16 25

n = 10
prev = 1
puts (1..n).inject([1]) { |acc, x|
    acc << acc.last + x * x
}.inspect
