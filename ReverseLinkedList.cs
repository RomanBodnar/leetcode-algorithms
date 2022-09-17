namespace algorithms.LeetCode;

//Given the head of a singly linked list, reverse the list, and return the reversed list.
// Input: head = [1,2,3,4,5]
// Output: [5,4,3,2,1]

public class ReverseLinkedList {

    public void Test()
    {
        var list1 = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4))));
        this.ReverseList(list1).PrintAll(4);
        this.ReverseList(new ListNode(1)).PrintAll(3);
    }

    public ListNode ReverseList(ListNode head) 
    {    
        if(head == null) return head;
        if(head.next == null) return head;
        
        var result = ReverseList(head.next);

        head.next.next = head;
        head.next = null;
        
        return result;
    }

}