using algorithms.Extensions;

namespace algorithms.LeetCode;

public class FloodFiller {

    public void Test()
    {
        var image = new int[3][];
        image[0] = new int[3] {0,0,2};
        image[1] = new int[3] {0,0,0};
        image[2] = new int[3] {0,0,0};
        this.FloodFill(image, 1, 1, 4).Dump();
        
    }

    public int[][] FloodFill(int[][] image, int sr, int sc, int color) {
        var currentColor = image[sr][sc];
        if(currentColor == color) return image;
        var queue = new Queue<(int h, int v)>();
        queue.Enqueue((sr,sc));
        while(queue.Any())
        {
            var index = queue.Dequeue();
            image[index.h][index.v] = color;
            if(index.h - 1 >= 0 && image[index.h - 1][index.v] == currentColor)
            {
                queue.Enqueue((index.h - 1, index.v));
            }
            if(index.h + 1 < image.GetLength(0) && image[index.h + 1][index.v] == currentColor)
            {
                queue.Enqueue((index.h + 1, index.v));
            }
            if(index.v - 1 >= 0 && image[index.h][index.v - 1] == currentColor)
            {
                queue.Enqueue((index.h, index.v - 1));
            }
            if(index.v + 1 < image[0].Length && image[index.h][index.v + 1] == currentColor)
            {
                queue.Enqueue((index.h, index.v + 1));
            }
        }

        return image;
    }
}