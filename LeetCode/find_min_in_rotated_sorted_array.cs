using System;

class Program {
    static int Min(int[] a) {
        int low = 0;
        int high = a.Length - 1;
        while (low < high) {
            if (a[low] < a[high]) {
                return a[low];
            }

            if (high - low == 1) {
                return Math.Min(a[high], a[low]);
            }

            int mid = low + (high - low) / 2;
            
            if (a[low] < a[mid]) {
                low = mid;
            } else {
                high = mid;
            }
        }

        return -1;
    }

    static void Main() {
        int[] a = new int[] {4, 5, 7, 0, 1, 2};
        Console.WriteLine(Min(a));
    }
}
