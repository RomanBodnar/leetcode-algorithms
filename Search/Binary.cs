namespace algorithms.Search;

public class Binary
{
    public void Test()
    {
        Console.WriteLine(this.Search(new int[]{9}, 9));
    }

    public int Search(int[] nums, int target) {
        var left = 0;
        var right = nums.Length - 1;
        
        while(left <=right)
        {
            var middle = (int)Math.Floor(((double)(left + right) / 2));
            Console.WriteLine(middle);
            if(nums[middle] > target)
            {
                right = middle - 1;
            }
            else if(nums[middle] < target)
            {
                left = middle + 1;
            }
            else
            {
                return nums[middle];
            }
        }
        return -1;
    }
}