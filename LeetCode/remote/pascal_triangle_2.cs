//  https://leetcode.com/problems/pascals-triangle-ii/
//
//  Given an index k, return the kth row of the Pascal's triangle.
//
//  For example, given k = 3,
//  Return [1,3,3,1]. 

//  https://leetcode.com/submissions/detail/52811939/
//
//
//  Submission Details
//  34 / 34 test cases passed.
//      Status: Accepted
//      Runtime: 428 ms
//          
//          Submitted: 0 minutes ago

public class Solution {
    public IList<int> GetRow(int rowIndex) {
        return Enumerable
               .Range(1, rowIndex)
               .Aggregate(
                   new List<int> { 1 },
                   (acc, x) => new List<int> { 1 }
                               .Concat(acc.Zip(acc.Skip(1), (a, b) => a + b))
                               .Concat(new List<int> { 1 })
                               .ToList());
    }
}

//  https://leetcode.com/submissions/detail/57181885/
//
//  Submission Details
//  34 / 34 test cases passed.
//      Status: Accepted
//      Runtime: 440 ms
//          
//          Submitted: 0 minutes ago
//  Meh, this should be really fucking fast and efficient :(

public class Solution {
    public IList<int> GetRow(int rowIndex) {
        if (rowIndex == 0)
        {
            return new List<int> { 1 };
        }
        
        var list = new LinkedList<int>();
        
        return
        Enumerable
        .Range(1, rowIndex)
        .Aggregate(list, (acc, x) => {
            var it = list.First;
            while (it != null)
            {
                var next = it.Next;
                if (it.Next != null)
                {
                    list.AddAfter(it, new LinkedListNode<int>(it.Value + it.Next.Value));
                }
                
                list.Remove(it);
                it = next;
            }
            
            list.AddFirst(1);
            list.AddLast(1);
            return list;
        }).ToList();
    }
}
