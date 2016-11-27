//  https://leetcode.com/problems/pacific-atlantic-water-flow/
//
//  OJ is down but it was accepted
public class Solution {
    public IList<int[]> PacificAtlantic(int[,] matrix) {
        var queue = new Queue<Tuple<int, int, int>>();
        var result = new HashSet<KeyValuePair<int, int>>();
        var codes = new int[matrix.GetLength(0), matrix.GetLength(1)];
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            queue.Enqueue(Tuple.Create(i, -1, 1));
            queue.Enqueue(Tuple.Create(i, matrix.GetLength(1), 2));
        }

        for (var i = 0; i < matrix.GetLength(1); i++)
        {
            queue.Enqueue(Tuple.Create(-1, i, 1));
            queue.Enqueue(Tuple.Create(matrix.GetLength(0), i, 2));
        }

        var directions = new [] { 
                Tuple.Create(-1, 0),
                Tuple.Create(1, 0),
                Tuple.Create(0, -1),
                Tuple.Create(0, 1) };

        while (queue.Any())
        {
            var current = queue.Dequeue();
            if (Bounded(matrix, current) && codes[current.Item1, current.Item2] == 3)
            {
                result.Add(new KeyValuePair<int, int>(current.Item1, current.Item2));
            }

            foreach (var x in directions) {
                var next = Tuple.Create(current.Item1 + x.Item1, current.Item2 + x.Item2, current.Item3);
                if (Bounded(matrix, next) &&
                    (codes[next.Item1, next.Item2] == 3 - current.Item3 ||
                     codes[next.Item1, next.Item2] == 0) &&
                    (!Bounded(matrix, current) || matrix[current.Item1, current.Item2] <= matrix[next.Item1, next.Item2]))
                    {
                        codes[next.Item1, next.Item2] += current.Item3;
                        queue.Enqueue(next);
                    }
            }
        }

        return result.Select(x => new [] {x.Key, x.Value}).ToList();
    }

    static bool Bounded(int[,] matrix, Tuple<int, int, int> x) {
        return 0 <= x.Item1 && x.Item1 < matrix.GetLength(0) &&
               0 <= x.Item2 && x.Item2 < matrix.GetLength(1);
    }
}
