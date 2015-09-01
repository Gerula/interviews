using System;
using System.Linq;

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }

    public override String ToString() {
        return String.Format("{0} {1}", val, next == null? String.Empty : next.ToString());
    }
}

class Program {
    // https://leetcode.com/submissions/detail/38308373/
    //
    //
    // Submission Details
    // 130 / 130 test cases passed.
    //  Status: Accepted
    //  Runtime: 692 ms
    //      
    //      Submitted: 0 minutes ago
    //
    //
    //      We need to make this faster!
    //
    public static ListNode MergeKLists(ListNode[] lists) {
        return lists.ToList().Aggregate((ListNode) null, (a, b) => {
                    return Merge2Lists(a, b);
                });
    }

    public static ListNode Merge2Lists(ListNode first, ListNode second) {
        if (first == null) {
            return second;
        }

        if (second == null) {
            return first;
        }

        if (first.val < second.val) {
            first.next = Merge2Lists(first.next, second);
            return first;
        }

        second.next = Merge2Lists(first, second.next);
        return second;
    }

    static void Main() {
        ListNode[] lists = new ListNode[3];
        int maxFirst = 10;
        int maxGlobal = 1000;
        Random rand = new Random();
        for (int i = 0; i < 3; i++) {
            int prev = rand.Next(maxFirst, maxGlobal);
            int count = rand.Next(4, 10);
            for (int j = 0; j < count; j++) {
                lists[i] = new ListNode(rand.Next(1, prev)) { next = lists[i] };
                prev = lists[i].val;
            }
        }

        Console.WriteLine(String.Join(", ", lists.Select(x => x.ToString())));
        Console.WriteLine(MergeKLists(lists).ToString());
    }
}
