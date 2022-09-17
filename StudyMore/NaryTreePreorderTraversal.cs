namespace algorithms.LeetCode;
// Given the root of an n-ary tree, return the preorder traversal of its nodes' values.
// Nary-Tree input serialization is represented in their level order traversal. 
// Each group of children is separated by the null value (See examples)

// Input: root = [1,null,3,2,4,null,5,6]
// Output: [1,3,5,6,2,4]



public class NaryTreePreorderTraversal {

    public void Test() {

        var root = new Node(1);

        var children3 = new List<Node> { new Node(5), new Node(6)};
        var childrenRoot = new List<Node> { new Node(3, children3), new Node(2), new Node(4)};
        root.children = childrenRoot;
        var a = this.Preorder(root);
        foreach(var b in a)
        {
            Console.Write($" {b}");
        }

    }

    public IList<int> Preorder(Node root) {
        if(root == null) return new List<int>{};
        var list = new List<int>();
        
        var stack = new Stack<Node>();
        stack.Push(root);
        while(stack.Any())
        {
            var a = stack.Pop();
            list.Add(a.val);
            if(a.children == null) continue;
            for(int i = a.children.Count - 1; i >= 0; i--)
            {
                stack.Push(a.children[i]);
                // if(!list.Contains(a.children[i].val))
                // {
                //     stack.Push(a.children[i]);
                // }
            }
        }

        return list;
    }
}