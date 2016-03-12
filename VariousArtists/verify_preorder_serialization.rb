#   https://leetcode.com/problems/verify-preorder-serialization-of-a-binary-tree/
#   Given a string of comma separated values,
#   verify whether it is a correct preorder traversal serialization of a binary tree.
#   Find an algorithm without reconstructing the tree.
#   
#   Submission Details
#   150 / 150 test cases passed.
#       Status: Accepted
#       Runtime: 80 ms
#           
#           Submitted: 0 minutes ago
#   You are here!
#   Your runtime beats 100.00% of rubysubmissions.
#
#   https://leetcode.com/submissions/detail/56112340/
def is_valid_serialization(preorder)
    degrees = 1
    preorder.split(",").each { |x|
        degrees -= 1
        return false if degrees < 0
        if x != "#"
            degrees += 2
        end
    }

    degrees == 0
end

[["9,3,4,#,#,1,#,#,2,#,6,#,#", true],
 ["1,#", false],
 ["9,#,#,1", false]].each { |s, result|
    puts "#{s} expected [#{result}] actual [#{is_valid_serialization(s)}]"
 }
