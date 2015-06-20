using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main() {
        int[] histogram = new int[] {6, 2, 5, 4, 5, 1, 6};
        Stack<int> stack = new Stack<int>();
        int max = 0;
        int i = 0;
        while (i < histogram.Length) {
            if (!stack.Any() || histogram[i] > histogram[stack.Peek()]) {
                stack.Push(i++);
            } else {
                int topIndex = stack.Pop();
                int area = histogram[topIndex] * (stack.Any() ? i - stack.Peek() - 1 : i);
                max = (area > max) ? area : max;
            }
        }

        while (stack.Any()) {
            int topIndex = stack.Pop();
            int area = histogram[topIndex] * (stack.Any() ? i - stack.Peek() - 1 : i);
            max = (area > max) ? area : max;
        }

        Console.WriteLine(max);
    }
}
