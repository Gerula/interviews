// https://leetcode.com/problems/partition-list/
//
// Given a linked list and a value x, partition it such that all nodes less than x come before nodes greater than or equal to x.
//
// You should preserve the original relative order of the nodes in each of the two partitions.
//
// For example,
// Given 1->4->3->2->5->2 and x = 3,
// return 1->2->2->4->3->5. 
//

using System;

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
    public override String ToString()
    {
        return String.Format("{0} {1}", val, next == null ? String.Empty : next.ToString());
    }
}

public class Solution {
    public ListNode Partition(ListNode head, int x) {
        var lower = new ListNode(-1);
        var higher = new ListNode(-1);
        var lowerPointer = lower;
        var higherPointer = higher;
        var it = head;
        while (it != null)
        {
            var nextNode = it.next;
            it.next = null;
            if (it.val < x)
            {
                lowerPointer.next = it;
                lowerPointer = lowerPointer.next;
            }
            else
            {
                higherPointer.next = it;
                higherPointer = higherPointer.next;
            }

            it = nextNode;
        }

        lowerPointer.next = higher.next;
        return lower.next;
    }

    static void Main()
    {
        ListNode root = null;
        foreach (var i in new [] {2, 5, 2, 3, 4, 1})
        {
            root = new ListNode(i) { next = root };
        }

        Console.WriteLine(root);
        Console.WriteLine(new Solution().Partition(root, 3));
    }
}
