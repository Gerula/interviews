using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program {
    static void Main() {
        Dictionary<char, char> closed = new Dictionary<char, char>();
        closed['}'] = '{';
        closed[')'] = '(';
        closed[']'] = '[';
        bool flag = false;
        Stack<char> stack = new Stack<char>();

        using (StreamReader reader = new StreamReader("check_brackets.cs")) {
            while (!reader.EndOfStream) {
                char c = (char) reader.Read();
                if (c == '\'' || c == '\"') {
                    flag = !flag;
                }
                
                if (flag) {
                    continue;
                }

                if (closed.Values.Contains(c)) {
                    stack.Push(c);
                } else if (closed.Keys.Contains(c)) {
                    if (!stack.Any() || stack.Pop() != closed[c]) {
                        Console.WriteLine("Bad parenthesis"); 
                        return;
                    }
                }
                Console.Write(c);
            }
        }

        Console.WriteLine(stack.Any() ? "Bad parenthesis" : "Good parenthesis");
    }
}
