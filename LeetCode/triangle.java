// https://leetcode.com/submissions/detail/35932764/

public class Solution {
    public int minimumTotal(List<List<Integer>> triangle) {
        for (int j = triangle.size() - 2; j >= 0; j--) {
            for (int i = 0; i < triangle.get(j).size(); i++) {
                triangle.get(j).set(i, Math.min(triangle.get(j + 1).get(i), triangle.get(j + 1).get(i + 1)) + triangle.get(j).get(i));
            }
        }
        
        return triangle.get(0).get(0);
    }
}
