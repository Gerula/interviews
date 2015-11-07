// https://leetcode.com/problems/copy-list-with-random-pointer/
//
//  A linked list is given such that each node contains an additional random pointer which could point to any node in the list or null.
//
//  Return a deep copy of the list. 
//

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
    }
}
