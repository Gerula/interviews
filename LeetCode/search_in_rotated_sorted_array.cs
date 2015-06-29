using System;

class Program {
    static void Main() {
        int[] a = new int[] {4, 6, 7, 0, 1, 2};

        int low = 0;
        int high = a.Length - 1;
        int target = 1;
        int idx = -1;
        while (low <= high) {
            int mid = low + (high - low) / 2;
            if (a[mid] == target) {
                idx = mid;
                break;
            }

            if (a[low] <= a[mid]) {
                if (a[mid] > target && target >= a[low]) {
                    high = mid - 1;
                } else {
                    low = mid + 1;
                }
            } else {
                if (a[mid] < target && target <= a[high]) {
                    low = mid + 1;
                } else {
                    high = mid - 1;
                }
            }
        }

        Console.WriteLine(idx);
    }
}
