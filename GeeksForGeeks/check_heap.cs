// http://www.geeksforgeeks.org/how-to-check-if-a-given-array-represents-a-binary-heap/
// Given an array, how to check if the given array represents a Binary Max-Heap.

using System;

static class Program 
{
    static bool IsHeap(this int[] a, Func<int, int, bool> order, int index)
    {
        if (index == a.Length - 1)
        {
            return true;
        }

        int left = Left(index);
        int right = Right(index);

        return (left >= a.Length || order(a[index], a[left]) && a.IsHeap(order, left)) &&
               (right >= a.Length || order(a[index], a[right]) && a.IsHeap(order, right));
    }

    static bool IsMaxHeap(this int[] a)
    {
        return a.IsHeap((x, y) => { return x >= y; }, 0);
    }

    static bool IsMinHeap(this int[] a)
    {
        return a.IsHeap((x, y) => { return x <= y; }, 0);
    }

    static int Left(int i)
    {
        return i * 2 + 1;
    }

    static int Right(int i)
    {
        return i * 2 + 2;
    }

    static void Main()
    {
        int[] a = new [] {90, 15, 10, 7, 12, 2};
        Console.WriteLine("{0} MaxHeap? {1} MinHeap? {2}",
                          String.Join(", ", a),
                          a.IsMaxHeap(),
                          a.IsMinHeap());
        
        a = new [] {9, 15, 10, 7, 12, 11};
        Console.WriteLine("{0} MaxHeap? {1} MinHeap? {2}",
                          String.Join(", ", a),
                          a.IsMaxHeap(),
                          a.IsMinHeap());}
}
