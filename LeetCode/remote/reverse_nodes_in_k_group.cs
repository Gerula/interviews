// https://leetcode.com/problems/reverse-nodes-in-k-group/
//
//  Given a linked list, reverse the nodes of a linked list k at a time and return its modified list.
//
//  If the number of nodes is not a multiple of k then left-out nodes in the end should remain as it is.
//
//  You may not alter the values in the nodes, only nodes itself may be changed.
//
//  Only constant memory is allowed.
//
//  For example,
//  Given this linked list: 1->2->3->4->5
//
//  For k = 2, you should return: 2->1->4->3->5
//
//  For k = 3, you should return: 3->2->1->4->5 
//
// 
// Submission Details
// 81 / 81 test cases passed.
//  Status: Accepted
//  Runtime: 172 ms
//      
//      Submitted: 0 minutes ago
//      

using System;
using System.Linq;

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }

    public override string ToString()
    {
        return String.Format(" {0}{1}", val, next == null ? String.Empty : next.ToString());
    }
}

public class Solution {
    public static ListNode ReverseKGroup(ListNode head, int k) {
        var iterator = head;
        ListNode last = null;
        while (iterator != null)
        {
            var count = 0;
            ListNode start = iterator;
            ListNode end = iterator;
            while (iterator != null && count < k)
            {
                end = iterator;
                iterator = iterator.next;
                count++;
            }

            if (count != k)
            {
                break;
            }
            
            end.next = null;
            if (last != null)
            {
                last.next = null;
            }

            var newList = Reverse(start);
            if (last == null)
            {
                head = newList;
            }
            else
            {
                last.next = newList;
            }

            start.next = iterator;
            last = start;
        }

        return head;
    }

    public static ListNode Reverse(ListNode head)
    {
        ListNode pre = null;
        while (head != null)
        {
            ListNode next = head.next;
            head.next = pre;
            pre = head;
            head = next;
        }

        return pre;
    }

    public static ListNode Generate(int n)
    {
        ListNode head = null;
        Enumerable.Range(1, n).Reverse().ToList().ForEach(x => {
            head = new ListNode(x) {
                next = head
            };
        });
        
        return head;
    }

    static void Main()
    {
        var head = Generate(5);
        Console.WriteLine(head);
        head = ReverseKGroup(head, 2);
        Console.WriteLine(head);
        Console.WriteLine();
        head = Generate(5);
        Console.WriteLine(head);
        head = ReverseKGroup(head, 3);
        Console.WriteLine(head);
    }
}
