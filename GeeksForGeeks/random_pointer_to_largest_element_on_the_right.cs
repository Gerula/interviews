//  http://www.geeksforgeeks.org/point-arbit-pointer-greatest-value-right-side-node-linked-list/
//  Given singly linked list with every node having an additional “arbitrary” pointer that currently points to NULL.
//  We need to make the “arbitrary” pointer to greatest value node in a linked list on its right side.

using System;
using System.Linq;

class ListNode 
{
    public int Val { get; set; }
    public ListNode Next { get; set; }
    public ListNode Rand { get; set; }

    public override String ToString()
    {
        return String.Format(
                "C:({0}) R:({1}) | {2}",
                this.Val,
                this.Rand == null ? String.Empty : this.Rand.Val.ToString(),
                this.Next == null ? String.Empty : this.Next.ToString());
    }
}

class Solution
{
    static ListNode MaxRandom(ListNode list)
    {
        if (list == null || list.Next == null)
        {
            return list;
        }

        list.Rand = MaxRandom(list.Next);
        return list.Val > list.Rand.Val ? list : list.Rand;
    }

    static void Main()
    {
        var rand = new Random();
        var list = Enumerable
                   .Range(0, rand.Next(20))
                   .Select(x => rand.Next(20))
                   .Aggregate(
                           new ListNode { Val = -1 },
                           (acc, x) => {
                                return new ListNode { Val = x, Next = acc };
                           });

        Console.WriteLine(list); 
        MaxRandom(list);
        Console.WriteLine(list);
    }
}
