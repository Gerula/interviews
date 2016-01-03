//  http://careercup.com/question?id=5703298884567040

using System;
using System.Linq;

static class Program
{
    static int Balance(this int[] a)
    {
        var rightSum = a.Sum();
        var leftSum = 0;
        var minDiff = int.MaxValue;
        var idx = -1;
        for (var i = 0; i < a.Length; i++)
        {
            leftSum += a[i];
            rightSum -= a[i];
            var diff = Math.Abs(leftSum - rightSum);
            if (diff == 0)
            {
                return i;
            }

            if (diff < minDiff)
            {
                minDiff = diff;
                idx = i;
            }
        }

        return idx;
    }

    static int Balans(this int[] a)
    {
        var low = 0;
        var high = a.Length - 1;
        var lowSum = 0;
        var highSum = 0;
        while (low <= high)
        {
            if (lowSum < highSum)
            {
                lowSum += a[low];
                low++;
            }
            else
            {
                highSum += a[high];
                high--;
            }
        }

        return low;
    }

    static void Main()
    {
        var r = new Random();
        for (var i = 0; i < 20; i++)
        {
            var len = r.Next(5, 15);
            var a = Enumerable.Repeat(1, len).Select(x => (r.Next(1, 10) % 2 == 0 ? -1 : 1) * r.Next(1, 10)).ToArray();
            var idx = a.Balance();
            var idx2 = a.Balans();
            Console.WriteLine(
                    "{0} - <{1}><2> [{3}]={4} [{5}]={6}",
                    String.Join(", ", a),
                    idx,
                    idx2,
                    String.Join(", ", a.Take(idx + 1)),
                    a.Take(idx + 1).Sum(),
                    String.Join(", ", a.Skip(idx + 1)),
                    a.Skip(idx + 1).Sum());
        }
    }
}
