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

class MinHeap {
    private const int MaxSize = 10000;
    public int Size { get; private set; }
    private ListNode[] storage;

    public override String ToString() {
        return String.Format("{0} {1}", Size, String.Join(",", storage.ToList().Where(y => y != null).Select(x => x.val)));
    }

    public MinHeap() {
        storage = new ListNode[MaxSize];
        Size = 0;
    }

    public void Add(ListNode value) {
        storage[Size] = value;
        Size++;
        HeapifyUp();
    }

    public ListNode Remove() {
        ListNode result = storage[0];
        storage[0] = storage[Size - 1];
        Size--;
        HeapifyDown();
        return result;
    }

    private void HeapifyUp() {
        int target = Size - 1;
        int parent = Parent(target);
        while (target > 0 && storage[parent].val > storage[target].val) {
            ListNode c = storage[parent];
            storage[parent] = storage[target];
            storage[target] = c;
            target = parent;
        }

        return;
    }

    private void HeapifyDown() {
        int target = 0;
        while (target < Size) {
            int min = target;
            int left = Left(target);
            int right = Right(target);
            if (left < Size && storage[target].val > storage[left].val) {
                min = left;
            }

            if (right < Size && storage[target].val > storage[right].val) {
                min = right;
            }
            
            if (min == target) {
                return;
            }

            ListNode c = storage[min];
            storage[min] = storage[target];
            storage[target] = c;
            target = min;
        }

        return;
    }

    private static int Parent(int child) {
        return (child - 1) / 2;
    }

    private static int Left(int node) {
        return node * 2 + 1;
    }

    private static int Right(int node) {
        return node * 2 + 2;
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

    public static ListNode MergeKLists2(ListNode[] lists) {
        MinHeap heap = new MinHeap();
        ListNode result = new ListNode(-1);
        ListNode tail = result;

        for (int i = 0; i < lists.Length; i++) {
            if (lists[i] != null) {
                heap.Add(lists[i]);
            }
        }

        while (heap.Size != 0) {
            tail.next = heap.Remove();
            tail = tail.next;

            if (tail.next != null) {
                heap.Add(tail.next);
            }
        }

        return result.next;
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

    public static ListNode[] GenerateLists() {
        ListNode[] result = new ListNode[4];
        int maxFirst = 10;
        int maxGlobal = 1000;
        Random rand = new Random();
        for (int i = 0; i < 4; i++) {
            int prev = rand.Next(maxFirst, maxGlobal);
            int count = rand.Next(4, 10);
            for (int j = 0; j < count; j++) {
                result[i] = new ListNode(rand.Next(1, prev)) { next = result[i] };
                prev = result[i].val;
            }
        }
    
        return result;
    }

    static void Main() {
        ListNode[] firstLists = GenerateLists();
        ListNode[] secondLists = GenerateLists();
        Console.WriteLine(String.Join(", ", firstLists.Select(x => x.ToString())));
        Console.WriteLine(MergeKLists(firstLists).ToString());
        Console.WriteLine(String.Join(", ", secondLists.Select(x => x.ToString())));
        Console.WriteLine(MergeKLists2(secondLists).ToString());
    }
}
