namespace algorithms.LeetCode;


// You are given an integer array cost where cost[i] is the cost of ith step on a staircase. Once you pay the cost, you can either climb one or two steps.

// You can either start from the step with index 0, or the step with index 1.

// Return the minimum cost to reach the top of the floor.

// Input: cost = [10,15,20]
// Output: 15
// Explanation: You will start at index 1.
// - Pay 15 and climb two steps to reach the top.
// The total cost is 15.

// Input: cost = [1,100,1,1,1,100,1,1,100,1]
// Output: 6
// Explanation: You will start at index 0.
// - Pay 1 and climb two steps to reach index 2.
// - Pay 1 and climb two steps to reach index 4.
// - Pay 1 and climb two steps to reach index 6.
// - Pay 1 and climb one step to reach index 7.
// - Pay 1 and climb two steps to reach index 9.
// - Pay 1 and climb one step to reach the top.
// The total cost is 6.


public class MinimalCostClimbingStairs {
    public int MinCostClimbingStairs(int[] cost) {
        int[] dp = new int[cost.Length + 1];
        int takeOneStep = -1;
        int takeTwoStep = -1;
        
        for(int i = 2; i < dp.Length; i++)
        {
            /*
                Two ways to reach step i:
                1. Take 1 step
                2. Take 2 steps
                
                1. If we take 1 step: cost of that step => cost[i - 1] + combined cost till [i - 1] step
                2. Likewise, if we take 2 steps to reach step i: total cost till i => cost[i - 2] + combined cost till [i - 2] steps
                so, dp[i] will be min of above two (as we can either take 1 step or 2 steps)
            */
            takeOneStep = dp[i - 1] + cost[i - 1];
            takeTwoStep = dp[i - 2] + cost[i - 2];
            dp[i] = Math.Min(takeOneStep, takeTwoStep);
        }
        
        return dp[dp.Length - 1];
    }
}