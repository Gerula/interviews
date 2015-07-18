using System;
using System.Collections.Generic;
using System.Linq;

static class Program {
    static String SimplifyPath(this String path) {
        Stack<String> stack = new Stack<String>();
        foreach (String element in path.Split(new char[] {'/'}, StringSplitOptions.RemoveEmptyEntries)) {
            switch (element) {
                case "..": if (stack.Count != 0) {
                               stack.Pop();
                           } 
                           
                           break;
                case ".": break;
                default: stack.Push(element);
                         break;
            }
        }

        return "/" + String.Join("/", stack.Reverse());
    }

    static void Main() {
        Console.WriteLine(String.Join(", ", new String[] {"/home/", "/a/./b/../../c/"}.Select(x => String.Format(" {0}={1} ", x, x.SimplifyPath()))));
    }
}
