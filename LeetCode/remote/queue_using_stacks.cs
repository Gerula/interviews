//  https://leetcode.com/problems/implement-queue-using-stacks/
//
//  Did it live
//
//  https://leetcode.com/submissions/detail/49490208/
//
//
//  Submission Details
//  17 / 17 test cases passed.
//      Status: Accepted
//      Runtime: 472 ms
//          
//          Submitted: 0 minutes ago
//

public class Queue {
    Stack<int> yard = new Stack<int>();
    Stack<int> storage = new Stack<int>();
    // Push element x to the back of queue.
    public void Push(int x) {
        storage.Push(x);
    }

    // Removes the element from front of queue.
    public void Pop() {
        while (storage.Count != 0)
        {
            yard.Push(storage.Pop());
        }
        
        yard.Pop();
        while (yard.Count != 0)
        {
            storage.Push(yard.Pop());
        }
    }

    // Get the front element.
    public int Peek() {
        while (storage.Count != 0)
        {
            yard.Push(storage.Pop());
        }
        
        var result = yard.Peek();
        while (yard.Count != 0)
        {
            storage.Push(yard.Pop());
        }        
        
        return result;
    }

    // Return whether the queue is empty.
    public bool Empty() {
        return storage.Count == 0;
    }
}
