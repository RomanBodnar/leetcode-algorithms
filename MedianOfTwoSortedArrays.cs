namespace algorithms.LeetCode;

public class MedianOfTwoSortedArrays
{
    public void Test()
    {
        Console.WriteLine(this.FindMedianSortedArrays(new [] {1,1}, new [] {1, 2}));
    }
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        var nums3 = nums1
            .Concat(nums2)
            .OrderBy(x => x)
            .Select(x => (double)x)
            .ToArray();

        var len = nums3.Length;
        if(len == 0) return 0.0;
        if(nums3.Length % 2 == 0)
        {
            return (nums3[len/2 - 1] + nums3[len/2])/2;
        }
        return nums3[len/2];
    }
}