namespace algorithms.LeetCode;

//Given the head of a singly linked list, return true if it is a palindrome or false otherwise.

// Input: head = [1,2,2,1]
// Output: true

// Input: head = [1,2]
// Output: false


// 1 -> 2 -> 2 -> 1
// 1 -> 2 -> 3 -> 2 -> 1

public class PalindromeLinkedList {

    public void Test()
    {
         var list1 = new ListNode(1, new ListNode(2, new ListNode(2, new ListNode(1))));
         Console.Write(this.IsPalindrome(list1));
    }
    public bool IsPalindrome(ListNode head) {
        if(head is null) return false;
        if(head.next is null) return true;
        var node = new ListNode(head.val, head.next);
        var stack = new Stack<ListNode>();
        do {
            stack.Push(node);
            node = node.next;
        }while(node != null);
        
        while(head != null)
        {
            if(head.val != stack.Pop().val) return false;
            head = head.next;
        }
        return true;
    }
}