namespace algorithms.LeetCode;

public class MiddleOfTheLinkedList 
{

    public void Test()
    {
        var list = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
        var list2 = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4))));
        var list3 = new ListNode(1, new ListNode(2));
        this.MiddleNode(list).Print();
        this.MiddleNode(list2).Print();
        this.MiddleNode(list3).Print();
    }

    public ListNode MiddleNode(ListNode head) 
    {
        if(head.next == null) return head;

        var second = new ListNode(head.val, head.next);
        int num = 1;

        while(second.next != null)
        {
            second = second.next;
            num++;
        }
        int middle = num/2;
        while(middle > 0)
        {
            head = head.next;
            middle--;
        }
        return head;
    }
    
    public ListNode MiddleNodeList(ListNode head) {
        List<ListNode> list = new List<ListNode>();
        
        while(head != null){
            list.Add(head);
            head = head.next;
        }
        
        return list[list.Count / 2];        
    }
}