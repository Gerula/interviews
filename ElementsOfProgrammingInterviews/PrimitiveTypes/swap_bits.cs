using System;

class Program {
    static int swap(int x, int l, int r) {
        if (((x >> l) & 1) != ((x >> r) & 1)) {
            return x ^= (1 << l) | (1 << r);
        }

        return x;
    }

    public static void Main(string[] args) {
        int x = new Random().Next(32, 1000);
        int y = swap(x, 2, 5);
        Console.WriteLine("{0} - {1} - {2}", x, Convert.ToString(x, 2), Convert.ToString(y,2));
    }
}
