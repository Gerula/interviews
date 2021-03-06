// http://www.geeksforgeeks.org/check-if-a-given-array-can-represent-preorder-traversal-of-binary-search-tree/
//
// Given an array of numbers, return true if given array can represent preorder traversal of a Binary Search Tree,
// else return false. Expected time complexity is O(n).
//

using System;
using System.Collections.Generic;

static class Program 
{
    static bool IsTraversal(this int[] a)
    {
        var stack = new Stack<int>();
        var root = int.MinValue;
        foreach (var node in a)
        {
            if (node < root)
            {
                return false;
            }

            while (stack.Count != 0 && stack.Peek() < node)
            {
                root = stack.Pop();
            }

            stack.Push(node);
        }

        return true;
    }

    static void Main()
    {
        if (!new [] {2, 4, 3}.IsTraversal())
        {
            throw new Exception("You are weak, expected true");
        }

        if (!new [] {40, 30, 35, 80, 100}.IsTraversal())
        {
            throw new Exception("You are weak, expected true");
        }

        if (new [] {2, 4, 1}.IsTraversal())
        {
            throw new Exception("You are weak, expected false");
        }

        if (new [] {40, 30, 35, 20, 80, 100}.IsTraversal())
        {
            throw new Exception("You are weak, expected false");
        }

        Console.WriteLine("All appears to be well");
    }
}
