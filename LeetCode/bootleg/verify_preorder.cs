//  http://lcoj.tk/problems/verify-preorder-serialization-of-a-binary-tree-dietpepsi-review/
//
//  Given a string of comma separated values,
//  verify whether it is a correct preorder traversal serialization of a binary tree.
//  Find an algorithm without reconstructing the tree.
//
//  A value in the string is either an integer or a character '#' representing null pointer.
//
//  A correct serialization will contain all the numbers and null pointers in the binary tree.

using System;
using System.Collections.Generic;

static class Program
{
    static bool ValidTree(this String a)
    {
        var s = new Stack<String>();
        foreach (var c in a.Split(new [] { ',' }))
        {
            if (c == "#")
            {
                if (s.Count == 0)
                {
                    return false;
                }

                s.Pop();
            }
            else
            {
                s.Push(c);
                s.Push(c);
            }
        }

        return s.Count == 0;
    }

    static void Main()
    {
        foreach (var x in new [] {
                    "9,3,4,#,#,1,#,#,2,#,6,#,#",
                    "1,#",
                    "9,#,#,1"
                })
        {
            Console.WriteLine("{0} - {1}", x, x.ValidTree());
        }
    }
}
