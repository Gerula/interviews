using System;
using System.Collections.Generic;
using System.Linq;

class SlidingWindow {
    public int Size { get; }
    private readonly IEnumerable<int> _data;

    public SlidingWindow(IEnumerable<int> data, int size) {
        Size = size;
        _data = data;
    }

    public IEnumerable<int> Max() {
        foreach (var x in _data) {
            yield return x;
        }
    }
}

class Program {
    static void Main() {
        Random generator = new Random();
        IEnumerable<int> data = Enumerable.Range(1, generator.Next(5,30)).Select(x => generator.Next(0, 30)).ToList();
        Console.WriteLine("Data:       [{0}]", String.Join(",", data.Select(x => String.Format("{0,3}", x))));
        Console.WriteLine("Max window: [{0}]", String.Join(",", new SlidingWindow(data, 4).Max().Select(x => String.Format("{0,3}", x))));
    }
}
