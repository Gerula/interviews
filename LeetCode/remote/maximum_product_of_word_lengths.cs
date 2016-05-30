//  https://leetcode.com/problems/maximum-product-of-word-lengths/
//  Given a string array words, find the maximum value of length(word[i]) * length(word[j])
//  where the two words do not share common letters.
//  You may assume that each word will contain only lower case letters.
//  If no such two words exist, return 0. 
//  https://leetcode.com/submissions/detail/58798912/
public class Solution {
    public int MaxProduct(string[] words) {
        var hash = words.Aggregate(
            new Dictionary<String, long>(),
            (acc, x) => {
                if (!acc.ContainsKey(x))
                {
                    acc[x] = x.Aggregate((long) 0, (a, b) => { 
                        return a | (1 << (b - 'a'));
                    });
                }
                    
                return acc;
            });
        
        var max = 0;
        for (var i = 1; i < words.Length; i++)
        {
            for (var j = 0; j < i; j++)
            {
                if ((hash[words[i]] & hash[words[j]]) == 0)
                {
                    max = Math.Max(max, words[i].Length * words[j].Length);
                }
            }
        }
        
        return max;
    }

    public int MaxProduct(string[] words) {
        var hash = words.Aggregate(
            new Dictionary<String, int>(),
            (acc, x) => {
               acc[x] = x.Aggregate(0, (a, y) => {
                  return a | (1 << y - 'a'); 
               });
               
               return acc;
            });
        
        return words.Select(x => words.Where(y => (hash[x] & hash[y]) == 0).DefaultIfEmpty(String.Empty).Select(y => y.Length * x.Length).Max()).DefaultIfEmpty(0).Max();
    }
}

