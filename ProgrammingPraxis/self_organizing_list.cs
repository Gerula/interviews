// http://programmingpraxis.com/2015/11/06/self-organizing-lists/
//
// Today’s exercise looks at a simple algorithm that is appropriate for search in a set that isn’t too big,
// doesn’t change too often, and isn’t searched too many times, where the definition of “too” depends on the needs of the user.
// The idea is to store the items of the set in a linked list, search the list on request, and each time an item is found,
// move it to the front of the list. The hope is that frequently-accessed items will stay near the front of the list,
// so that instead of an average search that requires inspection of half the list, frequently-accessed items are found much more quickly.
//
// Your task is to write functions that maintain a set as a self-organizing list:
// you should provide functions to insert and delete items from the set as well as to search within the set.
// When you are finished, you are welcome to read or run a suggested solution,
// or to post your own solution or discuss the exercise in the comments below.
//

using System;
using System.Linq;

class SelfOrgList<T>
{
    private class Node<U>
    {
        public U Val { get; set; }
        public Node<T> Next { get; set; }
        
        public override String ToString()
        {
            return String.Format("{0} {1}", 
                                 Val.ToString(), 
                                 Next == null ? String.Empty : Next.ToString());
        }
    }

    private Node<T> head = new Node<T> { Next = null };
    
    public void Add(T val)
    {
        head.Next = new Node<T> { Val = val, Next = head.Next }; 
    }

    public bool Contains(T val)
    {
        if (head.Next == null)
        {
            return false;
        }

        var prev = head;
        var it = head.Next;
        while (it != null && !it.Val.Equals(val))
        {
            prev = it;
            it = it.Next;
        }

        if (it == null)
        {
            return false;
        }

        prev.Next = it.Next;
        it.Next = head.Next;
        head.Next = it;
        return true;
    }

    public override String ToString()
    {
        if (head.Next == null) 
        {
            return String.Empty;
        }

        return head.Next.ToString();
    }
}

class Program 
{
    static void Main()
    {
        var list = new SelfOrgList<int>();
        Enumerable.Range(1, 10).ToList().ForEach(x => list.Add(x));
        Console.WriteLine("Added elements {0}", list);
        Enumerable.Range(5, 10).ToList().ForEach(x => {
                Console.WriteLine("Searched for {0} found? {1}", x, list.Contains(x));
                Console.WriteLine("After searchging for {0} {1}", x, list);
        });
    }
}
