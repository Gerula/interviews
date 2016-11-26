//  https://leetcode.com/problems/minimum-genetic-mutation/
//  https://leetcode.com/submissions/detail/83831919/
//
//  Submission Details
//  14 / 14 test cases passed.
//      Status: Accepted
//      Runtime: 149 ms
//          Submitted: 0 minutes ago
//



public class Solution {
    public int MinMutation(string start, string end, string[] bank) {
        var mutations = 0;
        var genes = new HashSet<String>(bank);
        var queue = new Queue<String>();
        queue.Enqueue(start);
        var currentLevel = 1;
        var nextLevel = 0;
        while (queue.Any()) {
            var current = queue.Dequeue();
            if (current == end) {
                return mutations;
            }

            foreach (var mutation in Mutate(current).Where(x => genes.Contains(x))) {
                queue.Enqueue(mutation);
                genes.Remove(mutation);
                nextLevel++;
            }

            currentLevel--;
            if (currentLevel == 0) {
                currentLevel = nextLevel;
                nextLevel = 0;
                mutations++;
            }
        }

        return -1;
    }

    public IEnumerable<String> Mutate(String gene) {
        var mutation = new StringBuilder(gene);
        const String letters = "ACGT";
        for (var i = 0; i < gene.Length; i++) {
            var actual = mutation[i];
            foreach (var letter in letters.Where(x => x != actual)) {
                mutation[i] = letter;
                yield return mutation.ToString();
            }

            mutation[i] = actual;
        }
    }
}
