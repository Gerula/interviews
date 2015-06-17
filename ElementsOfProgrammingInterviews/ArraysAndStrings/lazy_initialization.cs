using System;

class Array {
    public int Size { get; private set; }
    private readonly int[] sparse;
    private readonly int[] dense;
    private readonly int[] data;
    private int index = -1;

    public Array(int size) {
        sparse = new int[size];
        dense = new int[size];
        data = new int[size];
    }

    public bool IsInitialized(int idx) {
        return (sparse[idx] <= index) && (dense[sparse[idx]] == idx);
    }

    public int this[int idx] {
        get {
            return IsInitialized(idx) ? data[idx] : -1;
        }
        set {
            if (!IsInitialized(idx)) {
                index++;
                data[idx] = value;
                sparse[idx] = index;
                dense[index] = idx;
            } else {
                data[idx] = value;
            }
        }
    }
}

class Program {
    static void Main() {
        Array a = new Array(10);
        a[1] = 20;
        a[2] = 30;
        Console.WriteLine(a[1]);
        Console.WriteLine(a[2]);
        Console.WriteLine(a[3]);
        a[2] = 20;
        Console.WriteLine(a[2]);
    }
}
