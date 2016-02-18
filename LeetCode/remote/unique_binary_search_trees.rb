#   https://leetcode.com/problems/unique-binary-search-trees/
#
#   Given n, how many structurally unique BST's (binary search trees) that store values 1...n?
#
#   For example,
#   Given n = 3, there are a total of 5 unique BST's. 

#   TLE
def num_trees(n)
    trees(1, n)
end

def trees(low, high)
    low >= high ? 1 : low.upto(high).map { |x| trees(low, x - 1) * trees(x + 1, high) }.inject(:+)
end
