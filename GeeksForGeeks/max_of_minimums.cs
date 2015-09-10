using System;
using System.Collections.Generic;

class Dequeue {
    private LinkedList<int> data = new LinkedList<int>();
    private int maxSize;

    public Dequeue(int size) {
        maxSize = size;
    }

    public void Add(int item) {
        while (data.Count > 0 && item < data.Last.Value) {
            data.RemoveLast();
        }

        data.AddLast(item);
        
        if (data.Count > maxSize) {
            data.RemoveFirst();
        }
    }

    public int GetMin() {
        if (data.Count == 0) {
            return int.MaxValue;
        }

        return data.First.Value;
    }
}

static class Program {
    static int MaxOfMinimums(this List<int> s, int window) {
        Dequeue dequeue = new Dequeue(window);
        int max = int.MinValue;

        for (int i = 0; i < window; i++) {
            dequeue.Add(s[i]);
            max = dequeue.GetMin();
        }

        for (int i = window; i < s.Count - window; i++) {
            dequeue.Add(s[i]);
            int windowMin = dequeue.GetMin();
            max = windowMin > max ? windowMin : max;
        }

        return max;
    }

    static void Main() {
        List<int> input = new List<int> {10, 20, 30, 50, 10, 70, 30};
        Console.WriteLine("Input {0}", String.Join(",", input));

        for (int i = 1; i <= 3; i++) {
            Console.WriteLine("max of min of size {0} is {1}", i, input.MaxOfMinimums(i));
        }
    }
}
