//  https://leetcode.com/problems/evaluate-reverse-polish-notation/
//
//   Evaluate the value of an arithmetic expression in Reverse Polish Notation.
//
//   Valid operators are +, -, *, /. Each operand may be an integer or another expression. 

//  https://leetcode.com/submissions/detail/53038532/
//
//
//  Submission Details
//  20 / 20 test cases passed.
//      Status: Accepted
//      Runtime: 156 ms
//          
//          Submitted: 0 minutes ago
//

public class Solution {
    public int EvalRPN(string[] tokens) {
        var stack = new Stack<int>();
        foreach (var x in tokens)
        {
            var term = 0;
            if (int.TryParse(x, out term))
            {
                stack.Push(term);
            }
            else
            {
                stack.Push(Compute(stack.Pop(), stack.Pop(), x));
            }
        }
        
        return stack.Pop();
    }
    
    public int Compute(int b, int a, string op)
    {
        switch (op)
        {
            case "+": return a + b;
            case "-": return a - b;
            case "/": return a / b;
            case "*": return a * b;
        }
        
        return 0;
    }
}
