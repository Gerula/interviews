using System;

class Program {
    static void DutchFlagThis(int[] a, int pivot) {
        int size = a.Length;
        int low = -1;
        int high = size;
        int undecided = 0;
        while (undecided < high) {
            if (a[undecided] > pivot) {
                high--;
                swap(ref a[undecided], ref a[high]);
            }
            else if (a[undecided] == pivot) {
                undecided++;
            }
            else
            {
                low++;
                swap(ref a[undecided], ref a[low]);
                undecided++; 
            }
        }
    }

    static void swap(ref int i, ref int j) {
        int aux = i;
        i = j;
        j = aux;
    }

    static void Main() {
        int[] a = new int[] {3, 4, 4, 4, 1, 2, 5, 6, 1, 9};
        Console.WriteLine(String.Join(",", a));
        DutchFlagThis(a, 4);
        Console.WriteLine(String.Join(",", a));
    }
}
