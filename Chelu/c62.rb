#  Given a list of lists of strings such as:
#  {("a1", "a2"),
#  ("b1")
#  ("c1", "c2", "c3")}
#  Print them in this order: "a1", "b1", "c1", "a2", "c2", "c3"
#
#  Again choice of data structure makes or breaks this problem. 
#

a= [["a1", "a2"],
    ["b1"],
    ["c1", "c2", "c3"]]

result = []
a.map{ |x| x.size }.max.times do
    a.each do |x|
        result << x.shift unless !x.any?
    end
end

puts result.inspect
