//  https://leetcode.com/problems/spiral-matrix/
//
//  Given a matrix of m x n elements (m rows, n columns), return all elements of the matrix in spiral order. 
//

//  https://leetcode.com/submissions/detail/52900246/
//
//
//  Submission Details
//  22 / 22 test cases passed.
//      Status: Accepted
//      Runtime: 568 ms
//          
//          Submitted: 0 minutes ago

public class Solution {
    public IList<int> SpiralOrder(int[,] matrix) {
        var start = Tuple.Create(0, -1);
        var offset = GetOffset(new [] {
            Tuple.Create(0, 1),
            Tuple.Create(1, 0),
            Tuple.Create(0, -1),
            Tuple.Create(-1, 0)
        }).GetEnumerator();
        offset.MoveNext();
        return matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0 ?
               new List<int>() :
               Enumerable
               .Range(0, matrix.GetLength(0) * matrix.GetLength(1))
               .Select(x => {
                   var next = Tuple.Create(start.Item1 + offset.Current.Item1,
                                           start.Item2 + offset.Current.Item2);
 
                   if (0 > next.Item1 || next.Item1 >= matrix.GetLength(0) ||
                       0 > next.Item2 || next.Item2 >= matrix.GetLength(1) ||
                       matrix[next.Item1, next.Item2] == int.MaxValue)
                       {
                           offset.MoveNext();
                           next = Tuple.Create(start.Item1 + offset.Current.Item1,
                                               start.Item2 + offset.Current.Item2);
                       }
                       
                   var result = matrix[next.Item1, next.Item2];
                   start = next;
                   matrix[next.Item1, next.Item2] = int.MaxValue;
                   return result;
               })
               .ToList();
    }
    
    public IEnumerable<Tuple<int, int>> GetOffset(IEnumerable<Tuple<int, int>> offsets)
    {
        while (true)
        {
            foreach (var x in offsets)
            {
                yield return x;
            }
        }
    }
}
