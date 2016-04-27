//  http://www.byte-by-byte.com/sortstacks/
//
//  Given a stack, sort the elements in the stack using one additional stack.
//  eg.
//
//  sort([1, 3, 2, 4]) = [1, 2, 3, 4]
//
//  Once you think that you’ve solved the problem, head to the next page for the solution.

using System;
using System.Collections.Generic;

static class Solution
{
    static Stack<int> Sort(Stack<int> s)
    {
        var sorted = new Stack<int>();

        while (s.Count > 0)
        {
            var current = s.Pop();
            while (sorted.Count > 0 && sorted.Peek() < current)
            {
                s.Push(sorted.Pop());
            }

            sorted.Push(current);
        }

        return sorted;
    }

    static void Main()
    {
        var random = new Random();
        var times = random.Next(2, 6);
        for (var i = 0; i < times; i++)
        {
            var stack = new Stack<int>();
            var count = random.Next(5, 20);
            for (var j = 0; j < count; j++)
            {
                stack.Push(random.Next(100));
            }

            Console.WriteLine(
                    "{0} - {1}",
                    String.Join(", ", stack), 
                    String.Join(", ", Sort(stack)));
        }
    }
}
