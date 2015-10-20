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
using System.Linq;

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

    public double Extract()
    {
        double result = storage[0];
        storage[0] = storage[Size - 1];
        Size--;
        int idx = 0;
        while (idx < Size)
        {
            int gt = idx;
            gt = (!Comparer(storage[idx], storage[Left(idx)]) && Left(idx) < Size) ? Left(idx) : gt;
            gt = (!Comparer(storage[idx], storage[Right(idx)]) && Right(idx) < Size) ? Right(idx) : gt;
            if (gt == idx)
            {
                break;
            }

            Swap(ref storage[idx], ref storage[gt]);
            idx = gt;
        }

        return result;
    }

    private int Parent(int x)
    {
        return (x - 1) / 2;
    }

    private int Left(int x)
    {
        return x * 2 + 1;
    }

    private int Right(int x)
    {
        return x * 2 + 2;
    }

    private void Swap(ref double a, ref double b)
    {
        double c = a;
        a = b;
        b = c;
    }

    public override String ToString()
    {
        return String.Format("Sz: {0}, {1}", Size, String.Join(", ", storage.Where(x => x != 0)));
    }
}

public class MedianFinder {
    Heap maxHeap = new Heap((x, y) => x > y);
    Heap minHeap = new Heap((x, y) => x < y);

    public void AddNum(double num) {
        if (maxHeap.Size == 0)
        {
            maxHeap.Add(num);
            return;
        }

        if (minHeap.Size == 0)
        {
            minHeap.Add(num);
            return;
        }

        maxHeap.Add(num);
        if (minHeap.Head < maxHeap.Head || minHeap.Size < maxHeap.Size + 1)
        {
            minHeap.Add(maxHeap.Extract());
        }

        if (maxHeap.Size < minHeap.Size)
        {
            maxHeap.Add(minHeap.Extract());
        }
    }

    public double FindMedian() {
        if (maxHeap.Size == minHeap.Size)
        {
            return (maxHeap.Head + minHeap.Head) / 2;
        }
        else
        {
            return ((minHeap.Size > maxHeap.Size)? minHeap : maxHeap).Head;
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
        mf = new MedianFinder();
        mf.AddNum(1);
        Console.WriteLine(mf.FindMedian());
        mf = new MedianFinder();
        mf.AddNum(-1);
        Console.WriteLine(mf.FindMedian());
        mf.AddNum(-2);
        Console.WriteLine(mf.FindMedian());
        mf.AddNum(-3);
        Console.WriteLine(mf.FindMedian());
        mf.AddNum(-4);
        Console.WriteLine(mf.FindMedian());
        mf.AddNum(-5);
        Console.WriteLine(mf.FindMedian());
    }
}
