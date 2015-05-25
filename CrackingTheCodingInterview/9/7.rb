#  A circus is designing a tower routine consisting of people standing atop one anoth- er’s shoulders. For practical and aesthetic reasons, each person must be both shorter and lighter than the person below him or her. Given the heights and weights of each person in the circus, write a method to compute the largest possible number of peo- ple in such a tower.
#  EXAMPLE:
#  Input (ht, wt): (65, 100) (70, 150) (56, 90) (75, 190) (60, 95) (68, 110)
#  Output: The longest tower is length 6 and includes from top to bottom: (56, 90) (60,95) (65,100) (68,110) (70,150) (75,190)
#

a = [[65, 100], [70, 150], [56, 90], [75, 80], [75, 190], [60, 95], [68, 110]]

a.sort!{|x, y| 
   if x[0] == y[0]
       x[1] <=> y[1]
   else
       x[0] <=> y[0]
   end
}

seq_start = 0
seq_end = 0
prev = a[0]
max_seq_start = 0
max_seq_end = 1
a.each.with_index{ |x, i|
    seq_end = i
    if prev[0] > x[0] || prev[1] > x[1]
       seq_end -= 1
       if (max_seq_end - max_seq_start) <
          (seq_end - seq_start)

          max_seq_end, max_seq_start = seq_end, seq_start
       end
       seq_start = i
    end
    prev = x
}

puts a.inspect
puts a[max_seq_start..max_seq_end].inspect
