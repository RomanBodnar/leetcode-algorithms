// There is a robot on an m x n grid. The robot is initially located at the top-left corner (i.e., grid[0][0]). The robot tries to move to the bottom-right corner (i.e., grid[m - 1][n - 1]). 
// The robot can only move either down or right at any point in time.
// Given the two integers m and n, 
// return the number of possible unique paths that the robot can take to reach the bottom-right corner.
// The test cases are generated so that the answer will be less than or equal to 2 * 109.


// Input: m = 3, n = 2
// Output: 3
// Explanation: From the top-left corner, there are a total of 3 ways to reach the bottom-right corner:
// 1. Right -> Down -> Down
// 2. Down -> Down -> Right
// 3. Down -> Right -> Down

//assume dp[i][j] is the number of unique paths to reach (i, j). dp[i][j] = dp[i][j -1] + dp[i - 1][j]. 


using algorithms.Extensions;

public class UniquePathsMatrix {
    // m - number of rows
    // n - number of columns
    public int UniquePaths(int m, int n) {
        if(m == 1 || n == 1)
        {
            return 1;
        }
        var visited = new int[m,n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                visited[i,j] = -1;
            }
        }
        return GetPaths(0, 0);

        int GetPaths(int x, int y)
        {
            if(x == m - 1 && y == n - 1)
            {
                return 1;
            }
            if(visited[x,y] != -1)
            {
                return visited[x,y];
            }
            var result = 0;
            if(y < n - 1) result += GetPaths(x, y + 1);
            if(x < m - 1) result += GetPaths(x + 1, y);
            visited[x,y] = result;
            return result;
        }
    }

    public void Test()
    {
        this.UniquePaths(2, 2).Dump();
        this.UniquePaths(4, 1).Dump();
        this.UniquePaths(3, 2).Dump();
        this.UniquePaths(3, 3).Dump();
        this.UniquePaths(3, 7).Dump();
    }
}