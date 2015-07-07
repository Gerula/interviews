using System;
using System.Threading.Tasks;

class Program {
    static void DoStuffTo(int[] b, Func<int, int, int> func, Action<int> action) {
        foreach (int i in b) {
            Console.WriteLine(func(i, 1));
            action(i);
        }
    }

    static void Main() {
        int[] a = new int[] {1, 2, 3, 4};
        DoStuffTo(a,
                  (x, y) => {
                      return x + y;
                  },
                  x => {
                      Console.WriteLine(x + 2);
                  });
    }
}
