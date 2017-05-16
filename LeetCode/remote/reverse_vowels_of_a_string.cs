//  https://leetcode.com/problems/reverse-vowels-of-a-string/
//  Write a function that takes a string as input and reverse only the vowels of a string.
//
//  Example 1:
//  Given s = "hello", return "holle".
//
//  Example 2:
//  Given s = "leetcode", return "leotcede". 
//
//  https://leetcode.com/submissions/detail/59926034/
//
//  Submission Details
//  481 / 481 test cases passed.
//      Status: Accepted
//      Runtime: 160 ms
//          
//          Submitted: 0 minutes ago
public class Solution {
    public string ReverseVowels(string s) {
        var vowels = new [] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        var low = 0;
        var high = s.Length - 1;
        var sb = new StringBuilder(s);
        while (low < high)
        {
            while (low < high && !vowels.Contains(s[low]))
            {
                low++;
            }
            
            while (low < high && !vowels.Contains(s[high]))
            {
                high--;
            }
            
            var c = sb[low];
            sb[low++] = sb[high];
            sb[high--] = c;
        }
        
        return sb.ToString();
    }
}

//  https://leetcode.com/submissions/detail/59926946/
//
//  Submission Details
//  481 / 481 test cases passed.
//      Status: Accepted
//      Runtime: 188 ms
//          
//          Submitted: 0 minutes ago
public class Solution {
    public string ReverseVowels(string s) {
        var vowels = new [] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        var stack = new Stack<char>();
        foreach (var x in s)
        {
            if (vowels.Contains(x))
            {
                stack.Push(x);
            }
        }
        
        return new String(s.Select(x => {
            if (!vowels.Contains(x))
            {
                return x;
            }
            
            return stack.Pop();
        }).ToArray());
    }
}
