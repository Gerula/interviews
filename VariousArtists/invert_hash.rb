a = { 1 => [2, 3], 2 => [4, 5], 3 => [6, 7] }

puts a.inject({}) { |acc, x|
  x[1].each { |y|
    acc[y] ||= []
    acc[y] << x[0]
  }  

  acc
}.inspect
