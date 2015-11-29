// http://careercup.com/question?id=5643209168388096
//
// Validate JSON
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static bool ValidJson(this String s)
    {
        return true;
    }

    static void Main()
    {
        Console.WriteLine(String.Join(Environment.NewLine, new [] {
                        "{a: b}", "{a:b, c:d}", "{a:b, c:{e: f}}", "{a}", "{{a}}"
                    }.Select(x => String.Format("{0} - {1}", x, x.ValidJson()))));
    }
}
