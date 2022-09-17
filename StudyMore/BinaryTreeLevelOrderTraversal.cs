using algorithms.Extensions;

namespace algorithms.LeetCode;
//Given the root of a binary tree, return the level order traversal of its nodes' values. 
//(i.e., from left to right, level by level). BFS
public class BinaryTreeLevelOrderTraversal {

    public void Test()
    {
        var root = new TreeNode(3,
                        new TreeNode(9),
                        new TreeNode(20,
                            new TreeNode(15),
                            new TreeNode(7))
                        );
        var root2 = new TreeNode(1,
                        new TreeNode(2,
                            new TreeNode(4),
                            null!),
                        new TreeNode(3,
                            null!,
                            new TreeNode(5))
                        );
        root2.Dump();
        var list = this.LevelOrder(root2);
        list.Dump();
    }

    public IList<IList<int>> LevelOrder(TreeNode root) {
        var result = new List<IList<int>>();
        if(root ==  null) return result;
        var queue = new Queue<(TreeNode node, int lvl)>();
        result.Add(new List<int> {root.val});
        int level = 0;
        queue.Enqueue((root, level));

        while(queue.Any())
        {
            var head = queue.Dequeue();
            var left = head.node.left;
            var right = head.node.right;
            level = head.lvl;
            if(left is not null || right is not null) 
            {
                if(result.Count == level + 1 ){
                    result.Add(new List<int>());
                }
            }
            if(left != null) {
                result[level+1].Add(left.val);
                queue.Enqueue((left, level+1));
            }
            if(right != null) {
                result[level+1].Add(right.val);
                queue.Enqueue((right, level+1));
            }
        }
        return result;
    }
    public IList<IList<int>> LevelOrder2(TreeNode root) {
        if(root == null){
            return new List<IList<int>>();
        }
        
        List<IList<int>> answer = new List<IList<int>>();
       Queue<TreeNode> queue = new Queue<TreeNode>();
        
        queue.Enqueue(root);
        
        while(queue.Count > 0){
           
            int size = queue.Count, // number of nodes
            times = queue.Count; // size of level
            
            int[] list = new int[size]; 
            int i = 0;
            
            while(size > 0){
                
                TreeNode node = queue.Dequeue();
                
                list[i] = node.val;
                
                if(node.left != null){
                    queue.Enqueue(node.left);
                }
                if(node.right != null){
                    queue.Enqueue(node.right);
                }
                
                size--;
                i++;
            }
            answer.Add(list);
            
        }
        
        return answer;
    }
}
//         1
//     2       3
// 4               5

// head: 1
// left: 2
// right: 3

// head: 2
// left: 4
// right: 

// head: 3
// left: 
// right: 5

// head: 4
// left: 
// right: 

// head: 5
// left: 
// right: 
