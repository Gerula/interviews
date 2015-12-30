//  https://leetcode.com/submissions/detail/49303105/
//
//  Submission Details
//  17 / 17 test cases passed.
//      Status: Accepted
//      Runtime: 548 ms
//          
//          Submitted: 0 minutes ago

public class MinStack {
    Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
    
    public void Push(int x) {
        var min = stack.Any() && stack.Peek().Item2 < x ? stack.Peek().Item2 : x;
        stack.Push(Tuple.Create(x, min));
    }

    public void Pop() {
        stack.Pop();
    }

    public int Top() {
        return stack.Peek().Item1;
    }

    public int GetMin() {
        return stack.Peek().Item2;
    }
}
