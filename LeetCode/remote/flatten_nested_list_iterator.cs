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

//  https://leetcode.com/submissions/detail/64653177/
//
//  Submission Details
//  44 / 44 test cases passed.
//      Status: Accepted
//      Runtime: 500 ms
//          
//          Submitted: 0 minutes ago
public class NestedIterator {
    IEnumerator<int> enumerator;
    
    public NestedIterator(IList<NestedInteger> nestedList) {
        enumerator = nestedList.Select(x => Flatten(x)).SelectMany(x => x).GetEnumerator();
    }

    public bool HasNext() {
        return enumerator.MoveNext();
    }

    public int Next() {
        return enumerator.Current;
    }
    
    private IEnumerable<int> Flatten(NestedInteger integer) {
        if (integer.IsInteger()) {
            yield return integer.GetInteger();
            yield break;
        }
        
        foreach (var x in integer.GetList().Select(x => Flatten(x)).SelectMany(x => x))
        {
            yield return x;
        }
    }
}

//  https://leetcode.com/submissions/detail/59217310/
//
//  Submission Details
//  44 / 44 test cases passed.
//      Status: Accepted
//      Runtime: 548 ms
//          
//          Submitted: 0 minutes ago

public class NestedIterator {
    Stack<NestedInteger> stack = new Stack<NestedInteger>();
    NestedInteger current;
    
    public NestedIterator(IList<NestedInteger> nestedList) {
        foreach (var x in nestedList.Reverse())
        {
            stack.Push(x);
        }
    }

    public bool HasNext() {
        while (stack.Any())
        {
            var x = stack.Pop();
            if (x.IsInteger())
            {
                current = x;
                return true;
            }
            
            foreach (var nested in x.GetList().Reverse())
            {
                stack.Push(nested);
            }
        }
        
        return false;
    }

    public int Next() {
        return current.GetInteger();
    }
}

//  https://leetcode.com/submissions/detail/59218229/
//
//  Submission Details
//  44 / 44 test cases passed.
//      Status: Accepted
//      Runtime: 568 ms
//          
//          Submitted: 0 minutes ago
public class NestedIterator {
    IList<NestedInteger> flattened = new List<NestedInteger>();
    int index = 0;
    
    public NestedIterator(IList<NestedInteger> nestedList) {
        flattened = Flatten(nestedList);
    }
    
    IList<NestedInteger> Flatten(IList<NestedInteger> nestedList) {
        return nestedList.Select(x => {
            if (x.IsInteger())
            {
                return new List<NestedInteger> { x };
            }
            
            return Flatten(x.GetList());
        })
        .SelectMany(x => x)
        .ToList();
    }

    public bool HasNext() {
        return index < flattened.Count;
    }

    public int Next() {
        return flattened[index++].GetInteger();
    }
}
