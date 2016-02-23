//  https://www.reddit.com/r/dailyprogrammer/comments/46zm8m/20160222_challenge_255_easy_playing_with_light/

using System;
using System.Collections.Generic;
using System.IO;

class Node 
{
    public int On { get; private set; }
    public int LeftSide { get; private set; }
    public int RightSide { get; private set; }
    public Node Left { get; private set; }
    public Node Right { get; private set; }

    public static Node Build(int high, int low = 0)
    {
        if (low > high)
        {
            return null;
        }

        var mid = low + (high - low) / 2;
        return new Node { 
            On = 0, 
            LeftSide = low, 
            RightSide = high,
            Left = high == low ? null : Build(mid, low),
            Right = high == low ? null : Build(high, mid + 1)
        };
    }

    public void Switch(int low, int high)
    {
        if (LeftSide == RightSide && low == LeftSide && high == RightSide)
        {
            On = 1 - On;
            return;
        }

        if (high < LeftSide || RightSide < low)
        {
            return;
        }
    }

    public override String ToString()
    {
        return String.Format(
                "{0} ({1}, {2}) [{3}, {4}]",
                On,
                LeftSide,
                RightSide,
                Left == null ? "null" : Left.ToString(),
                Right == null ? "null" : Right.ToString());
    }
}

static class Solution
{
    static List<Tuple<int, int>> ReadIntervals(this StreamReader s)
    {
        String line;
        var result = new List<Tuple<int, int>>();
        while ((line = s.ReadLine()) != null)
        {
            var values = line.Split();
            var low = int.Parse(values[0]);
            var high = int.Parse(values[1]);
            result.Add(Tuple.Create(Math.Min(low, high), Math.Max(low, high)));
        }

        return result;
    }

    static int CountSwitches(this String filePath)
    {
        var n = 0;
        List<Tuple<int, int>> intervals;
        using (StreamReader s = new StreamReader(filePath))
        {
            n = int.Parse(s.ReadLine());
            intervals = s.ReadIntervals();
        }

        Node root = Node.Build(n - 1);
        foreach (var interval in intervals)
        {
            Console.WriteLine(interval);
            Console.WriteLine(root.On); 
            root.Switch(interval.Item1, interval.Item2);
            Console.WriteLine(root.On);
        }

        return root.On;
    }

    static void Main()
    {
        Console.WriteLine("1.in".CountSwitches());   
    }
}
