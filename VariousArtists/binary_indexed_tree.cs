using System;
using System.Collections.Generic;
using System.Linq;

class Bulbs
{
    private int[] a;

    public Bulbs(int max)
    {
        a = new int[max];
    }

    int Read(int i)
    {
        int result = 0;
        while (i > 0) 
        {
            result += a[i];
            i -= (i & -i);
        }

        return result;
    }

    void Update(int i, int val)
    {
        while (i < a.Length)
        {
            a[i] += val;
            i += (i & -i);
        }
    }

    public bool Get(int i)
    {
        return Read(i) % 2 == 1;
    }

    public Bulbs Toggle(int i, int j)
    {
        Update(i, 1);
        Update(j + 1, -1);
        return this;
    }

    public override String ToString()
    {
        return String.Join(
                String.Empty,
                a.Select((x, i) => Get(i) ? "X" : " "));
    }
}

static class Program 
{
    static IEnumerable<String> Decompose(this int n)
    {
        int pow = 0;
        while (n != 0)
        {
            if ((n & 1) == 1)
            {
                yield return String.Format("2^{0}", pow);
            }

            pow++;
            n >>= 1;
        }
    }

    static void Main()
    {
        var b = new Bulbs(40);
        b.
        Toggle(2, 10).
        Toggle(5, 15).
        Toggle(7, 30).
        Toggle(8, 20);
        Console.WriteLine(b);
    }
}
