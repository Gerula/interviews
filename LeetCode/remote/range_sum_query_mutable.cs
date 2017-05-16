//  https://leetcode.com/problems/range-sum-query-mutable/
//  https://leetcode.com/submissions/detail/85308737/

public class NumArray {
    int[] fenwick;
    int[] prevs;

    public NumArray(int[] nums) {
        fenwick = new int[nums.Length + 1];
        prevs = new int[nums.Length];
        for (var i = 0; i < nums.Length; i++) {
            Update(i, nums[i]);
        }
    }

    public void Update(int i, int val) {
        var diff = val - prevs[i];
        prevs[i] = val;
        i++;
        while (i < fenwick.Length) {
            fenwick[i] += diff;
            i = Next(i);
        }
    }

    public int SumRange(int i, int j) {
        return Sum(j) - Sum(i) + prevs[i];
    }

    private int Sum(int i) {
        var sum = 0;
        i++;
        while (i != 0) {
            sum += fenwick[i];
            i = Parent(i);
        }

        return sum;
    }

    private static int Parent(int i) {
        return i - (i & -i);
    }

    private static int Next(int i) {
        return i + (i & -i);
    }
}

