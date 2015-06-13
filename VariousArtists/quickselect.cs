using System;
using System.Collections;
using System.Linq;

class Program {

    private static int Select(int[] array, int order, Random random) {
        int left = 0;
        int right = array.Length - 1;

        while (left < right) {
            int pivot = array[random.Next(left, right)];
            int read = left;
            int write = right;
            while (read < write) {
                if (array[read] < pivot) {
                    read++;
                } else {
                    int aux = array[write];
                    array[write] = array[read];
                    array[read] = aux;
                    write--;
                }
            }

            if (order <= read) {
                right = read;
            } else {
                left = read + 1;
            }
        }

        return array[order];
    }

    public static void Main(string[] args) {
        int[] array = new int[10];
        Random random = new Random();
        for (int i = 0; i < array.Length; i++) {
            array[i] = random.Next(1, array.Length * array.Length);
        }

        Console.WriteLine("{0} - {1} - {2} - {3}",String.Join(",", array), String.Join(",", array.OrderBy(x => x)), 3, Select(array, 3, random));
    }
}
