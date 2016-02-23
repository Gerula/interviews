//  https://leetcode.com/problems/implement-stack-using-queues/
//
//  Favoring Push
//  https://leetcode.com/submissions/detail/54249105/
//  Submission Details
//  16 / 16 test cases passed.
//      Status: Accepted
//      Runtime: 488 ms
//          
//          Submitted: 1 hour, 15 minutes ago

public class Stack {
    private LinkedList<int> queue = new LinkedList<int>();
    private LinkedList<int> shunt = new LinkedList<int>();
    
    // Push element x onto stack.
    public void Push(int x) {
        if (queue.Any())
        {
            shunt.AddLast(queue.First());
            queue.RemoveFirst();
        }

        queue.AddLast(x);
    }

    // Removes the element on top of the stack.
    public void Pop() {
        queue.RemoveFirst();
        while (shunt.Any())
        {
            queue.AddLast(shunt.First());
            shunt.RemoveFirst();
        }
        
        if (!queue.Any())
        {
            return;
        }
        
        while (queue.Count != 1)
        {
            shunt.AddLast(queue.First());
            queue.RemoveFirst();
        }
    }

    // Get the top element.
    public int Top() {
        return queue.First();
    }

    // Return whether the stack is empty.
    public bool Empty() {
        return !queue.Any();
    }
}
