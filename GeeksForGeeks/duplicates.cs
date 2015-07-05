using System;
using System.Linq;

class Program {
    static void Main() {
        int[] a = new int[] {1, 1, 2, 2, 3, 4, 4, 5, 5, 6, 6};
        Console.WriteLine(a.Aggregate((x, y) => { return x ^ y; }));
    }
}
