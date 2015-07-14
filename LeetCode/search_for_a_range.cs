using System;

static class Program {
    private enum Direction {
        Rightmost,
        Leftmost
    }

    static Tuple<int, int> GetRange(this int[] a, int value) {
        return Tuple.Create(a.GetPosition(value, Direction.Leftmost),
                            a.GetPosition(value, Direction.Rightmost));
    }

    static int GetPosition(this int[] a, int value, Direction direction) {
        int low = 0;
        int high = a.Length;
        int index = -1;
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (a[mid] == value) {
                index = mid;
                switch (direction) {
                    case Direction.Leftmost: high = mid; break;
                    case Direction.Rightmost : low = mid + 1; break;
                }
            } else if (a[mid] < value) {
                low = mid + 1;
            } else {
                high = mid;
            }
        }     

        return index;
    }

    static void Main() {
        int[] a = new int[] {1, 2, 3, 4, 5, 5, 5, 5, 5, 6, 7};
        Console.WriteLine(a.GetRange(5));
    }
}
