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
using System.Text.RegularExpressions;

static class Program
{
    static bool ValidTree2(this String a)
    {
        var leaf = new Regex("[0-9]+,#,#");
        while (a != "#" && leaf.IsMatch(a))
        {
            a = leaf.Replace(a, "#");
        }

        return a == "#";
    }

    static bool ValidTree(this String a)
    {
        var diff = 1;
        foreach (var c in a.Split(new [] { ',' }))
        {
            if (--diff < 0)
            {
                return false;
            }

            if (c != "#")
            {
                diff += 2;
            }
        }

        return diff == 0;
    }

    static void Main()
    {
        foreach (var x in new [] {
                    "9,3,4,#,#,1,#,#,2,#,6,#,#",
                    "1,#",
                    "9,#,#,1"
                })
        {
            Console.WriteLine("{0} - {1} - {2}", x, x.ValidTree(), x.ValidTree2());
        }
    }
}
