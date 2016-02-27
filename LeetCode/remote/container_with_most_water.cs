//  https://leetcode.com/problems/container-with-most-water/
//  Given n non-negative integers a1, a2, ..., an, where each represents a point at coordinate (i, ai).
//  n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0).
//  Find two lines, which together with x-axis forms a container, such that the container contains the most water. 
//  https://leetcode.com/submissions/detail/54727048/

public class Solution {
    public int MaxArea(int[] height) {
        var low = 0;
        var high = height.Length - 1;
        var max = 0;
        while (low < high)
        {
            var h = Math.Min(height[high], height[low]);
            max = Math.Max((high - low) * h, max);
            while (low < high && height[low] <= h) { low++; }
            while (low < high && height[high] <= h) { high--; }
        }
        
        return max;
    }
}

//  https://leetcode.com/submissions/detail/54726730/
public class Solution {
    public int MaxArea(int[] height) {
        var low = 0;
        var high = height.Length - 1;
        var max = 0;
        while (low < high)
        {
            max = Math.Max((high - low) * Math.Min(height[high], height[low]), max);
            if (height[low] < height[high])
            {
                low++;
            }
            else 
            {
                high--;
            }
        }
        
        return max;
    }
}
