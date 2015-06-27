using System;
using System.Collections.Generic;
using System.Linq;

class SlidingWindow {
    public int Size { get; }
    private readonly List<int> _data;

    public SlidingWindow(List<int> data, int size) {
        Size = size;
        _data = data;
    }

    public List<int> Max() {
        List<int> result = new List<int>();
        LinkedList<int> dequeue = new LinkedList<int>();

        for (int i = 0; i < Size; i++) {
            while (dequeue.Any() && _data[dequeue.Last()] < _data[i]) {
                dequeue.RemoveLast();
            }

            dequeue.AddLast(i);
        }
        
        for (int i = 0; i < Size; i++) {
            result.Add(_data[dequeue.First()]);
        }

        for (int i = Size; i < _data.Count; i++) {
            result.Add(_data[dequeue.First()]);
            while(dequeue.Any() && dequeue.First() <= i - Size) {
                dequeue.RemoveFirst();
            }

            while (dequeue.Any() && _data[dequeue.Last()] < _data[i]) {
                dequeue.AddLast(i);
            }

            dequeue.AddLast(i);
        }

        return result;
    }
}

class Program {
    static void Main() {
        Random generator = new Random();
        List<int> data = Enumerable.Range(1, generator.Next(5,30)).Select(x => generator.Next(0, 30)).ToList();
        Console.WriteLine("Data:       [{0}]", String.Join(",", data.Select(x => String.Format("{0,3}", x))));
        Console.WriteLine("Max window: [{0}]", String.Join(",", new SlidingWindow(data, 4).Max().Select(x => String.Format("{0,3}", x))));
    }
}
