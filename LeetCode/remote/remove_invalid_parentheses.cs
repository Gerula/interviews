//  https://leetcode.com/problems/remove-invalid-parentheses/
//
//   Remove the minimum number of invalid parentheses in order to make the input string valid. Return all possible results.
//
//   Note: The input string may contain letters other than the parentheses ( and ). 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Solution {
    //  
    //  Submission Details
    //  125 / 125 test cases passed.
    //      Status: Accepted
    //      Runtime: 724 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //
    //          https://leetcode.com/submissions/detail/49296154/
    public IList<string> RemoveInvalidParentheses(string s) {
        var visited = new HashSet<String>();
        var queue = new Queue<String>();
        var result = new List<String>();
        queue.Enqueue(s);
        while (queue.Count != 0)
        {
            var current = queue.Dequeue();
            if (Valid(current))
            {
                result.Add(current);
            }

            if (result.Any())
            {
                continue;
            }

            foreach (var next in Enumerable
                                 .Range(0, current.Length)
                                 .Where(x => current[x] == '(' || current[x] == ')')
                                 .Select(x => String.Format("{0}{1}", current.Substring(0, x), current.Substring(x + 1)))
                                 .Where(x => !visited.Contains(x)))
            {
                visited.Add(next);
                queue.Enqueue(next);
            }
        }

        if (!result.Any())
        {
            result.Add(String.Empty);
        }

        return result;
    }

    public static bool Valid(String s)
    {
        var count = 0;
        var i = 0;
        while (i < s.Length && count >= 0)
        {
            switch(s[i++])
            {
                case '(': count++; break;
                case ')': count--; break;
            }
        }

        return count == 0;
    }

    //  https://leetcode.com/submissions/detail/60072837/
    //
    //  Submission Details
    //  125 / 125 test cases passed.
    //      Status: Accepted
    //      Runtime: 636 ms
    //          
    //          Submitted: 0 minutes ago
    //  Why yes, I am getting stupider
    public class Solution {
        public IList<string> RemoveInvalidParentheses(string s) {
            var queue = new Queue<String>();
            queue.Enqueue(s);
            var result = new List<String>();
            var visited = new HashSet<String> { s };
            while (queue.Any())
            {
                var current = queue.Dequeue();
                if (IsValidParentheses(current))
                {
                    if (result.Any() && result.Last().Length > current.Length)
                    {
                        break;
                    }
                    
                    result.Add(current);
                }
                else
                {
                    for (var i = 0; i < current.Length; i++)
                    {
                        if (current[i] != '(' && current[i] != ')')
                        {
                            continue;
                        }
                        
                        var next = current.Substring(0, i) + current.Substring(i + 1);
                        if (visited.Contains(next))
                        {
                            continue;
                        }
                        
                        visited.Add(next);
                        queue.Enqueue(next);
                    }
                }
            }
            
            return result;
        }
        
        public bool IsValidParentheses(String s)
        {
            var acc = 0;
            foreach (var x in s)
            {
                switch (x)
                {
                    case ')' : acc--;
                            if (acc < 0)
                            {
                                return false;
                            }
                            break;
                    case '(' : acc++;
                            break;
                    default  : break;
                }
            }
            
            return acc == 0;
        }
    }

    static void Main()
    {
        var s = new Solution();
        Console.WriteLine(String.Join(", ", s.RemoveInvalidParentheses("()())()")));
        Console.WriteLine(String.Join(", ", s.RemoveInvalidParentheses("(a)())()")));
        Console.WriteLine(String.Join(", ", s.RemoveInvalidParentheses(")(")));
        Console.WriteLine(String.Join(", ", s.RemoveInvalidParentheses("x(")));
    }
}
