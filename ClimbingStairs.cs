namespace algorithms.LeetCode;

// You are climbing a staircase. It takes n steps to reach the top.
// Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

// Input: n = 2
// Output: 2
// Explanation: There are two ways to climb to the top.
// 1. 1 step + 1 step
// 2. 2 steps

// Input: n = 3
// Output: 3
// Explanation: There are three ways to climb to the top.
// 1. 1 step + 1 step + 1 step
// 2. 1 step + 2 steps
// 3. 2 steps + 1 step

public class ClimbingStairs 
{
    private Dictionary<int, int> solutions = new Dictionary<int, int>();
    public ClimbingStairs()
    {
    }

    public void Test()
    {
        Console.WriteLine(ClimbStairs(3));
        Console.WriteLine(ClimbStairs(45));
    }

    public int ClimbStairs(int n) {
        if(solutions.ContainsKey(n)) return solutions[n];
        int result = 0;
        if (n == 0) return 0;
        if(n == 1) 
        {
            result = 1;
            return result;
        } 
        if(n == 2)
        {
            result = 2;
            return 2;
        }

        result += ClimbStairs(n - 1);
        result += ClimbStairs(n - 2);
        solutions[n] = result;
        return result;
    }
}