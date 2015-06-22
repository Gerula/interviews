using System;

class Program {
    static void Remove(int[] a, int n) {
        int length = a.Length;
        int write = 0;
        int read = 0;
        while (read < a.Length) {
            if (a[read] == n) {
                length--;
            } else {
                a[write++] = a[read];
            }
            read++;
        }

        Console.WriteLine("{0}-{1}", String.Join(",", a), length);
    }

    static void Main() {
        int[] array = new[] {1, 2, 1, 2, 3, 4, 5, 1, 2, 3, 4};
        Remove(array, 1);
    }
}
