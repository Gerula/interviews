//  https://leetcode.com/problems/flatten-nested-list-iterator/
//  Given a nested list of integers, implement an iterator to flatten it.
//
//  Each element is either an integer, or a list -- whose elements may also be integers or other lists.
//
//  https://leetcode.com/submissions/detail/59208022/
//
//  Submission Details
//  44 / 44 test cases passed.
//      Status: Accepted
//      Runtime: 532 ms
//          
//          Submitted: 0 minutes ago
public class NestedIterator {
    private IEnumerator<NestedInteger> Enumerator;
    private IEnumerable<NestedInteger> Enumerate(NestedInteger nestedInteger)
    {
        if (nestedInteger.IsInteger())
        {
            yield return nestedInteger;
        }
        else
        {
            foreach (var item in Enumerate(nestedInteger.GetList()))
            {
                yield return item;
            }
        }
    }
    
    private IEnumerable<NestedInteger> Enumerate(IList<NestedInteger> nestedList)
    {
        foreach (var item in nestedList.Select(x => Enumerate(x)).SelectMany(x => x))
        {
            yield return item;
        }
    }
    
    public NestedIterator(IList<NestedInteger> nestedList) {
        Enumerator = Enumerate(nestedList).GetEnumerator();
    }

    public bool HasNext() {
        return Enumerator.MoveNext();
    }

    public int Next() {
        return Enumerator.Current.GetInteger();
    }
}

