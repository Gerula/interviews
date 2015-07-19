// Evaluate Reverse Polish Notation Total Accepted: 46241 Total Submissions: 217951
//
// Evaluate the value of an arithmetic expression in Reverse Polish Notation.
//
// Valid operators are +, -, *, /. Each operand may be an integer or another expression.
// 
// Some examples:
//
//  ["2", "1", "+", "3", "*"] -> ((2 + 1) * 3) -> 9
//  ["4", "13", "5", "/", "+"] -> (4 + (13 / 5)) -> 6
//
// 20 / 20 test cases passed.
//  Status: Accepted
//  Runtime: 168 ms
//      
//      Submitted: 0 minutes ago
//

using System;
using System.Collections.Generic;

class Program {
    public static int EvalRPN(string[] tokens) {
        Stack<int> stack = new Stack<int>();
        foreach (string token in tokens) {
            switch (token) {
                case "+": stack.Push(stack.Pop() + stack.Pop()); break;
                case "*": stack.Push(stack.Pop() * stack.Pop()); break;
                case "-": 
                          int a = stack.Pop();
                          int b = stack.Pop();
                          stack.Push(b - a); break;
                case "/": 
                          a = stack.Pop();
                          b = stack.Pop();
                          stack.Push(b / a); break;
                default: stack.Push(Int32.Parse(token)); break;
            }
        }

        return stack.Peek();
    }

    static void Main() {
        Console.WriteLine(EvalRPN(new string[] {"2", "1", "+", "3", "*"}));
        Console.WriteLine(EvalRPN(new string[] {"4", "13", "5", "/", "+"}));
    }
}
