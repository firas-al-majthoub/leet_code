public class Solution
{
    public int MaxArea(int[] height)
    {
        int left = 0;
        int right = height.Length - 1;
        int res = 0;

        while (left < right)
        {
            int newVal = Math.Min(height[left], height[right]) * (right - left);
            res = Math.Max(res, newVal);

            if (height[left] <= height[right])
                left++;
            else
                right--;
        }

        return res;
    }



    /* ============ BRUTE FORCE ============ */


    // public int MaxArea(int[] height)
    // {
    //     int res = 0;
    //     for (int i = 0; i < height.Length - 1; i++)
    //     {
    //         for (int j = i + 1; j < height.Length; j++)
    //         {
    //             int newVal = Math.Min(height[i], height[j]) * (j - i);
    //             res = Math.Max(res, newVal);
    //         }
    //     }

    //     return res;
    // }
}
