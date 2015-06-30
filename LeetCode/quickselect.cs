using System;
using System.Linq;

class Program {
    static int QuickSelect(int[] a, int k) {
        int low = 0;
        int high = a.Length - 1;
        Random rand = new Random();
        while (low < high) {
            int mid = a[rand.Next(low, high + 1)];
            int left = low;
            int right = high;
            while (left < right) {
                if (a[left] >= mid) {
                    Swap(ref a[left], ref a[right]);
                    right--;
                } else {
                    left++;
                }
            }

            if (a[left] > mid) {
                left--;
            }

            if (left >=  k) {
                high = left;
            } else {
                low = left + 1;
            }
        }

        return a[k];
    }

    static void Swap(ref int a, ref int b) {
        int c = a;
        a = b;
        b = c;
    }

    static void Main() {
        Random random = new Random();
        int[] a = Enumerable.Range(0, 15).Select(x => random.Next(0, 20)).ToArray();
        Console.WriteLine(String.Join(",", a));
        Console.WriteLine(QuickSelect(a, 4));
        Console.WriteLine(String.Join(",", a.OrderBy(x => x)));
    }
}
