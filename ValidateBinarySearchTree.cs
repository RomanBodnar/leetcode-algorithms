namespace algorithms.LeetCode;
using algorithms.Extensions;

public class ValidateBinarySearchTree {

    public void Test()
    {
        //[5,4,6,null,null,3,7]
        var root2 = new TreeNode(5, 
                        new TreeNode(4),
                        new TreeNode(6,
                            new TreeNode(3),
                            new TreeNode(7)));
        IsValidBST(root2).Dump();
        array.Dump();
    }

    public bool IsValidBST(TreeNode root) {
        InorderTraversal(root);
        var sorted = array.OrderBy(x => x).Distinct().ToList();
        if(sorted.Count < this.array.Count) return false;
        return this.array.Zip(sorted).All(x => x.First == x.Second);
    }

    private List<int> array = new (20);
    public void InorderTraversal(TreeNode root) {
        if(root == null) return;
        InorderTraversal(root.left);
        array.Add(root.val);
        InorderTraversal(root.right);
       
    }
}