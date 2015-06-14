#  Given an array A. Return array B where B[i] = the product of all elements in A except for A[i]. You cannot use division.
#
#  Stupid puzzle problem. 
#

class Array
    def prod
        left = Array.new(self.size) do 
            1
        end
        right = Array.new(self.size) do
            1
        end
        n = self.size
        1.upto(n - 1).each do |i|
            left[i] = left[i - 1] * self[i - 1]
        end
        (n - 2).downto(0).each do |i|
            right[i] = right[i + 1] * self[i + 1]
        end

        left.zip(right).map{ |a, b| a * b }
    end
end

[[1, 2, 3, 4, 5, 6, 7], [1, 2, 3]].each { |x|
    puts "#{x.inspect} - #{x.prod}"
}
