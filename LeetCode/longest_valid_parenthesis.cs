using System;
using System.Collections.Generic;

class Program {
    static int Max(char[] p) {
        Stack<int> stack = new Stack<int>();
        int last = 0;
        int max = 0;
        for (int i = 0; i < p.Length; i++) {
            if (p[i] == '(') {
                stack.Push(i);
            } else {
                if (stack.Count == 0) {
                    last = i;
                } else {
                    stack.Pop();
                    if (stack.Count == 0) {
                        max = Math.Max(max, i - last);
                    } else {
                        max = Math.Max(max, i - stack.Peek());
                    }
                }
            }
        }

        return max; 
    }

    static void Main() {
        char[][] parenthesis = new char[][]{ new char[] {')', '(', ')', '(', ')', ')'}, new char[] {'(', '(', ')'}};
        foreach (var p in parenthesis) {
            Console.WriteLine("{0} - {1}", String.Join(",", p), Max(p));
        }
    }
}
