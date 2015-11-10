// https://leetcode.com/problems/copy-list-with-random-pointer/
//
//  A linked list is given such that each node contains an additional random pointer which could point to any node in the list or null.
//
//  Return a deep copy of the list. 
//
// this is fucking bullshit:
//
// My output:
//
// [1,#x] -> [2,#x] -> [3,#x] -> [4,#x] -> [5,#x] -> [6,#x] -> [7,#x] -> [8,#x] -> [9,#x] -> [10,#x] ->
// [1,#8] -> [2,#8] -> [3,#1] -> [4,#10] -> [5,#3] -> [6,#2] -> [7,#5] -> [8,#5] -> [9,#3] -> [10,#6] ->
// [1,#8] -> [2,#8] -> [3,#1] -> [4,#10] -> [5,#3] -> [6,#2] -> [7,#5] -> [8,#5] -> [9,#3] -> [10,#6] ->
// [1,#8] -> [2,#8] -> [3,#1] -> [4,#10] -> [5,#3] -> [6,#2] -> [7,#5] -> [8,#5] -> [9,#3] -> [10,#6] ->
// [100001,#100008] -> [100002,#100008] -> [100003,#100001] -> [100004,#100010] -> [100005,#100003] -> [100006,#100002] -> [100007,#100005] -> [100008,#100005] -> [100009,#100003] -> [100010,#100006] ->
// [1,#8] -> [2,#8] -> [3,#1] -> [4,#10] -> [5,#3] -> [6,#2] -> [7,#5] -> [8,#5] -> [9,#3] -> [10,#6] ->
//
// and the damn OJ says:
//
//  Input: {-1,1,#,#}
//  Output: Random pointer of node with label -1 points to a node from the original list.
//  Expected: {-1,1,#,#} 
//
//  That's fucking bullshit. I'm modifying the original list, the second doesn't change. What bullshit, man!!

using System;
using System.Linq;

public class RandomListNode {
    public int label;
    public RandomListNode next, random;
    public RandomListNode(int x)
    { 
        this.label = x; 
    }

    public RandomListNode this[int i] 
    {
        get
        {
            var it = this;
            var c = 0;
            while (c++ < i && it != null)
            {
                it = it.next;
            }

            return it;
        }
    }

    public override String ToString()
    {
        return String.Format(
                "[{0},#{1}] -> {2}",
                label.ToString(),
                random == null ? "x" : random.label.ToString(),
                next == null ? String.Empty : next.ToString()
                );
    }

    public int Length
    {
        get 
        {
            return 1 + (next == null ? 0 : next.Length);
        }
    }
}

class Program
{
    public static RandomListNode CopyRandomList(RandomListNode head) {
        if (head == null)
        {
            return null;
        }

        var it = head;
        while (it != null)
        {
            it.next = new RandomListNode(it.label) 
            {
                next = it.next,
                random = it.next
            };

            it = it.next.next;
        }

        var result = head.next;
        it = head;
        while (it != null)
        {
            if (it.random != null)
            {
                it.next.random = it.random.next;
            }

            it = it.next.next;
        }

        it = head;
        while (it != null)
        {
            var newNode = it.next;
            it.next = newNode.next;
            if (newNode.next != null)
            {
                newNode.next = newNode.next.next;
            }

            it = it.next;
        }

        return result;
    }

    static void Main()
    {
        RandomListNode head1 = null;
        Enumerable.
            Range(1, 10).
            Reverse().
            ToList().
            ForEach(x => {
                        head1 = new RandomListNode(x) {
                            next = head1
                        };
                    });

        Console.WriteLine(head1);
        
        Random random = new Random();
        for (int i = 0; i < head1.Length; i++)
        {
            head1[i].random = head1[random.Next(head1.Length)];
        }

        Console.WriteLine(head1);
        var head2 = CopyRandomList(head1);
        Console.WriteLine(head1);
        Console.WriteLine(head2);
        for (int i = 0; i < head1.Length; i++)
        {
            head1[i].label += 100000;
        }
        Console.WriteLine(head1);
        Console.WriteLine(head2);
        for (int i = 0; i < head1.Length; i++)
        {
            head2[i].label += 1;
        }
        Console.WriteLine(head1);
        Console.WriteLine(head2);
    }
}
