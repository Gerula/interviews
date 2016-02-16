//  https://leetcode.com/problems/copy-list-with-random-pointer/
//
//   A linked list is given such that each node contains an additional random pointer which could point to any node in the list or null.
//
//   Return a deep copy of the list. 

//  Finally nailed it.
//  https://leetcode.com/submissions/detail/53588998/
//
//  Submission Details
//  11 / 11 test cases passed.
//      Status: Accepted
//      Runtime: 112 ms
//          
//          Submitted: 0 minutes ago

public class Solution {
    public RandomListNode CopyRandomList(RandomListNode head, Dictionary<RandomListNode, RandomListNode> hash = null) {
        if (head == null)
        {
            return null;
        }
        
        if (hash == null)
        {
            hash = new Dictionary<RandomListNode, RandomListNode>();
        }
        
        if (hash.ContainsKey(head))
        {
            return hash[head];
        }
        
        hash[head] = new RandomListNode(head.label);
        hash[head].next = CopyRandomList(head.next, hash);
        hash[head].random = CopyRandomList(head.random, hash);
        return hash[head];
    }
}
