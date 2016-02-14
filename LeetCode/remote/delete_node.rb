#   Sweet memories from 2008...
#
#   https://leetcode.com/problems/delete-node-in-a-linked-list/
#
#    Write a function to delete a node (except the tail) in a singly linked list, given only access to that node. 

#   https://leetcode.com/submissions/detail/53446662/
#
#   
#   Submission Details
#   83 / 83 test cases passed.
#       Status: Accepted
#       Runtime: 88 ms
#           
#           Submitted: 0 minutes ago

def delete_node(node)
    node.val = node.next.val
    node.next = node.next.next
end
