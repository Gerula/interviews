using System;
using System.Linq;

class Program {
    static void Main() {
        int[] a = new int[] {5, 2, 10, 15, 8, 7};
        Console.WriteLine(a.OrderBy(x => x).Select((x, i) => {
                                                              if (i > 0) {
                                                                 return x - a[i - 1];
                                                              } else {
                                                                 return x;
                                                              }
                                                             }).Max());
    }
}
