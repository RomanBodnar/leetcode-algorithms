namespace algorithms.LeetCode;
using algorithms.Extensions;
public class NumberOfIslands 
{

    private UnionFind unionFind;
    private int numberOfIslands;

    public void Test()
    {

var gridRaw = @"[
    ['1','1','1','1','1','0','1','1','1','1','1','1','1','1','1','0','1','0','1','1'],
    ['0','1','1','1','1','1','1','1','1','1','1','1','1','0','1','1','1','1','1','0'],
    ['1','0','1','1','1','0','0','1','1','0','1','1','1','1','1','1','1','1','1','1'],
    ['1','1','1','1','0','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'],
    ['1','0','0','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'],
    ['1','0','1','1','1','1','1','1','0','1','1','1','0','1','1','1','0','1','1','1'],
    ['0','1','1','1','1','1','1','1','1','1','1','1','0','1','1','0','1','1','1','1'],
    ['1','1','1','1','1','1','1','1','1','1','1','1','0','1','1','1','1','0','1','1'],
    ['1','1','1','1','1','1','1','1','1','1','0','1','1','1','1','1','1','1','1','1'],
    ['1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'],
    ['0','1','1','1','1','1','1','1','0','1','1','1','1','1','1','1','1','1','1','1'],
    ['1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'],
    ['1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'],
    ['1','1','1','1','1','0','1','1','1','1','1','1','1','0','1','1','1','1','1','1'],
    ['1','0','1','1','1','1','1','0','1','1','1','0','1','1','1','1','0','1','1','1'],
    ['1','1','1','1','1','1','1','1','1','1','1','1','0','1','1','1','1','1','1','0'],
    ['1','1','1','1','1','1','1','1','1','1','1','1','1','0','1','1','1','1','0','0'],
    ['1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'],
    ['1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'],
    ['1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1']
]";

var a = Newtonsoft.Json.JsonConvert.DeserializeObject<char[][]>(gridRaw);


        char[][] grid = new char[3][]{
            new char[3]{'1', '1', '0'},
            new char[3]{'0', '0', '1'},
            new char[3]{'1', '0', '1'}
        };
        this.NumIslands(a).Dump();
    }

    public int NumIslands(char[][] grid) {
        int rows = grid.GetLength(0);
        int cols = grid[0].Length;
        this.unionFind = new UnionFind(rows * cols);
        this.numberOfIslands = 0;
        for(int i = 0; i < grid.GetLength(0); i++)
        {
            for(int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == '1')
                {
                    Console.WriteLine($"increase {this.numberOfIslands}");
                    numberOfIslands++;
                    Union(grid, i, j);
                }
            }
        }
        return numberOfIslands;
    }

    public void Union(char[][] map, int i, int j) {
        var currentColor = '1';
        int cols = map[0].Length;
        int rows = map.GetLength(0);
        int mark = cols * i + j;
        
        if(i - 1 >= 0 && map[i - 1][j] == currentColor)
        {
            if(this.unionFind.Union(cols * (i-1)+j, mark))
            {
                Console.WriteLine($"decrease {this.numberOfIslands}");
                this.numberOfIslands--;
            }
        }
        if(i + 1 < rows && map[i + 1][j] == currentColor)
        {
            if(this.unionFind.Union(cols * (i+1) + j, mark))
            {
                Console.WriteLine($"decrease {this.numberOfIslands}");
                this.numberOfIslands--;
            }
        }
        if(j - 1 >= 0 && map[i][j - 1] == currentColor)
        {
            if(this.unionFind.Union(cols * i + j - 1, mark))
            {
                Console.WriteLine($"decrease {this.numberOfIslands}");
                this.numberOfIslands--;
            }
        }
        if(j + 1 < map[0].Length && map[i][j + 1] == currentColor)
        {
            if(this.unionFind.Union(cols * i + j + 1, mark))
            {
                Console.WriteLine($"decrease {this.numberOfIslands}");
                this.numberOfIslands--;
            }
        }
    }
}
//  private int[][] directions = {{0, 1}, {0, -1}, {1, 0}, {-1, 0}};
//     private UF uf;
//     private int rows, cols, countIslands;
    
//     public int numIslands(char[][] grid) {
//         if (grid.length == 0) return 0;
        
//         rows = grid.length;
//         cols = grid[0].length;
//         uf = new UF(rows * cols);
        
//         countIslands = 0;
        
//         for (int x = 0; x < rows; x++) {
//             for (int y = 0; y < cols; y++) {
//                 // If value 1, union with adjacent
//                 if (grid[x][y] == '1') {
//                     countIslands++;
//                     unionAround(x, y, grid);
//                 }
//             }
//         }
        
//         return countIslands;
//     }
    
//     private void unionAround(int x, int y, char[][] grid) {
//         int mark = x * cols + y;
//         for (int[] dir : directions) {
//             int nx = x + dir[0];
//             int ny = y + dir[1];
//             if (nx >= 0 && nx < rows && ny >= 0 && ny < cols && grid[nx][ny] == '1') {
//                 if (uf.union(nx * cols + ny, mark)) {
//                     countIslands--;
//                 }
//             }
//         }
//     }
sealed class UnionFind
{
    private int[] parent;

    public UnionFind(int n)
    {
        this.parent = new int[n];
        for(int i = 0; i < n; i++)
        {
            this.parent[i] = i;
        }
    }

    public int Find(int x)
    {
        if(this.parent[x] == x) 
        {
            return x;
        }
        return this.parent[x] = this.Find(this.parent[x]);
    }

    public bool Union(int x, int y)
    {
        int rootX = this.Find(x);
        int rootY = this.Find(y);
        if(rootX == rootY)
        {
            return false;
        }
        this.parent[rootX] = rootY;
        return true;
    }
}



    
//     class UF {
//         int[] parent;

//         public UF(int n) {
//             parent = new int[n];
//             for (int i = 0; i < n; i++) {
//                 parent[i] = i;
//             }
//         }

//         private int find(int x) {
//             if (parent[x] == x) {
//                 return x;
//             }
//             return parent[x] = find(parent[x]); // Path compression
//         }

//         // Return false if x and y are in the same disjoint set already
//         public boolean union(int x, int y) {
//             int rootX = find(x);
//             int rootY = find(y);
//             if (rootX == rootY) {
//                 return false;
//             }
//             parent[rootX] = rootY;
//             return true;
//         }
//     }