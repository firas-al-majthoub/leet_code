public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int totalLength = nums1.Length + nums2.Length;

        if (totalLength % 2 == 1)
            return oddMedian(nums1, nums2);
        else
            return evenMedian(nums1, nums2);
    }

    private double oddMedian(int[] nums1, int[] nums2)
    {
        int totalLength = nums1.Length + nums2.Length;
        int medianLocation = totalLength / 2;
        int i = -1;
        int j = -1;

        int counter = 0;
        double median = 0;
        while (counter <= medianLocation)
        {
            if (i == nums1.Length - 1)
            {
                median = nums2[j + 1];
                j++;
            }
            else if (j == nums2.Length - 1)
            {
                median = nums1[i + 1];
                i++;
            }
            else if (nums1[i + 1] < nums2[j + 1])
            {
                median = nums1[i + 1];
                i++;
            }
            else
            {
                median = nums2[j + 1];
                j++;
            }

            counter++;
        }

        return median;
    }

    private double evenMedian(int[] nums1, int[] nums2)
    {
        int totalLength = nums1.Length + nums2.Length;
        int medianLocation = totalLength / 2;
        int i = -1;
        int j = -1;

        int counter = 0;
        double median = 0;
        double prevMedian = 0;
        while (counter <= medianLocation)
        {
            if (i == nums1.Length - 1)
            {
                prevMedian = median;
                median = nums2[j + 1];
                j++;
            }
            else if (j == nums2.Length - 1)
            {
                prevMedian = median;
                median = nums1[i + 1];
                i++;
            }
            else if (nums1[i + 1] < nums2[j + 1])
            {
                prevMedian = median;
                median = nums1[i + 1];
                i++;
            }
            else
            {
                prevMedian = median;
                median = nums2[j + 1];
                j++;
            }

            counter++;
        }

        return (prevMedian + median) / 2;
    }
}
