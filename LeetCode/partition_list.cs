// Partition List Total Accepted: 41508 Total Submissions: 151346
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

class Program {
  public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
  
    public override String ToString() {
        return String.Format("{0} {1}", val, next == null? String.Empty : next.ToString());
    }
  }

  static ListNode Partition(ListNode node, int threshold) {
      ListNode small = null;
      ListNode lastSmall = null;
      ListNode equal = null;
      ListNode lastEqual = null;
      ListNode larger = null;
      ListNode it = node;

      while (it != null) {
        ListNode next = it.next;
        if (it.val == threshold) {
            it.next = lastEqual; 
            if (equal == null) {
                equal = it;
            }

            lastEqual = it;
        } else if (it.val < threshold) {
            it.next = lastSmall; 
            if (small == null) {
                small = it;
            }

            lastSmall = it;
        } else {
            it.next = larger;
            larger = it;
        }

        it = next;
      }

      small.next = lastEqual;
      equal.next = larger;
      
      return lastSmall;
  }

  static void Main() {
      ListNode head = null;
      head = new ListNode(2) { next = head };
      head = new ListNode(5) { next = head };
      head = new ListNode(2) { next = head };
      head = new ListNode(3) { next = head };
      head = new ListNode(4) { next = head };
      head = new ListNode(1) { next = head };
      
      Console.WriteLine(head);
      Console.WriteLine(Partition(head, 3));
  }
}
