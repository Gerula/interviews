// https://leetcode.com/problems/find-median-from-data-stream/
//
// Median is the middle value in an ordered integer list. If the size of the list is even, there is no middle value. So the median is the mean of the two middle value.
// Examples:
//
// [2,3,4] , the median is 3
//
// [2,3], the median is (2 + 3) / 2 = 2.5
//
// Design a data structure that supports the following two operations:
//
//  void addNum(int num) - Add a integer number from the data stream to the data structure.
//  double findMedian() - Return the median of all elements so far.
//

using System;

public class Heap {
    private Func<double, double, bool> Comparer { get; set; }
    private readonly double[] storage;
    private const int MaxSize = 100000;

    public int Size { get; private set; }
    public double Head
    {
        get
        {
            return storage[0];
        }
    }

    public Heap(Func<double, double, bool> comparer)
    {
        Size = 0;
        storage = new double[MaxSize];
        Comparer = comparer;
    }

    public void Add(double item)
    {
        int idx = Size;
        Size++;
        storage[idx] = item;
        while (Parent(idx) != idx && !Comparer(storage[Parent(idx)], storage[idx]))
        {
            Swap(ref storage[Parent(idx)], ref storage[idx]);
            idx = Parent(idx);
        }
    }

    private int Parent(int x)
    {
        return (x - 1) / 2;
    }

    private void Swap(ref double a, ref double b)
    {
        double c = a;
        a = b;
        b = c;
    }
}

public class MedianFinder {
    Heap maxHeap = new Heap((x, y) => x >= y);
    Heap minHeap = new Heap((x, y) => x < y);

    public void AddNum(double num) {
        if (minHeap.Size <= maxHeap.Size)
        {
            minHeap.Add(num);
        }
        else 
        {
            maxHeap.Add(num);
        }
    }

    public double FindMedian() {
        if (maxHeap.Size == minHeap.Size)
        {
            return (maxHeap.Head + minHeap.Head) / 2;
        }
        else
        {
            return maxHeap.Head;
        }
    }
}

class Program
{
    static void Main()
    {
        MedianFinder mf = new MedianFinder();
        mf.AddNum(1);
        mf.AddNum(2);
        Console.WriteLine(mf.FindMedian());
        mf.AddNum(3);
        Console.WriteLine(mf.FindMedian());
        mf = new MedianFinder();
        mf.AddNum(2);
        mf.AddNum(3);
        mf.AddNum(4);
        Console.WriteLine(mf.FindMedian());
    }
}
