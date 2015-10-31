// http://www.lintcode.com/en/problem/number-of-islands-ii/
//
// Given a n,m which means the row and column of the 2D matrix and an array of pair A( size k).
// Originally, the 2D matrix is all 0 which means there is only sea in the matrix.
// The list pair has k operator and each operator has two integer A[i].x, A[i].y
// means that you can change the grid matrix[A[i].x][A[i].y] from sea to island.
// Return how many island are there in the matrix after each operator.
//

using System;
using System.Collections.Generic;
using System.Linq;

class Pair
{
    public int X;
    public int Y;

    public override String ToString()
    {
        return String.Format("[{0}, {1}]", X, Y);
    }

    public override int GetHashCode()
    {
        return X + Y;
    }

    public override bool Equals(Object other)
    {
        if (other == null)
        {
            return false;
        }

        var second = other as Pair;
        return X == second.X && Y == second.Y;
    }
}

static class Program
{
    static int[] Islands(this Pair[] ops)
    {
        var set = new HashSet<Pair>();
        return ops.Aggregate(
                new List<int>(),
                (acc, x) => {
                    var adjacent = false;    
                    for (int i = x.X - 1; i <= x.X + 1; i++)
                    {
                        for (int j = x.Y - 1; j <= x.Y + 1; j++)
                        {
                            adjacent = adjacent || set.Contains(new Pair { X = i, Y = j});
                        }
                    }

                    set.Add(x);
                    var last = acc.Count == 0 ? 0 : acc.Last();
                    acc.Add(last + (adjacent ? 0 : 1));
                    return acc;
                }).ToArray();
    }

    static void Main()
    {
        Console.WriteLine(String.Join(", ", new [] {
            new Pair { X = 0, Y = 0 },
            new Pair { X = 0, Y = 1 },
            new Pair { X = 2, Y = 2 },
            new Pair { X = 2, Y = 1 }
        }.Islands()));
    }
}

