//   https://www.careercup.com/question?id=5139875124740096

using System;

static class Solution
{
    static int Sum(this String s)
    {
        var level = 0;
        var acc = String.Empty;
        var sum = 0;
        foreach (var c in s)
        {
            switch (c)
            {
                case ' ': break;
                case '{': level++; 
                          break;
                case '}': sum += String.IsNullOrEmpty(acc) ? 0 : int.Parse(acc) * level;
                          acc = String.Empty;
                          level--;
                          break;
                case ',': sum += String.IsNullOrEmpty(acc) ? 0 : int.Parse(acc) * level;
                          acc = String.Empty;
                          break;
                default:  acc += c;
                          break;
            }
        }

        return sum;
    }

    static void Main()
    {
        Console.WriteLine("{{1, 1}, 2, {1, 1}}".Sum());
        Console.WriteLine("{1, {4, { 6 }}}".Sum());
    }
}
