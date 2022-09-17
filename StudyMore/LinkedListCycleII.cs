namespace algorithms.LeetCode;

// Given the head of a linked list, return the node where the cycle begins. 
// If there is no cycle, return null.
// There is a cycle in a linked list if there is some node in the list that can be 
// reached again by continuously following the next pointer. 
// Internally, pos is used to denote the index of the node that tail's next pointer is connected to (0-indexed). 
// It is -1 if there is no cycle. 
// Note that pos is not passed as a parameter.
// Do not modify the linked list.

// Input: head = [3,2,0,-4], pos = 1
// Output: tail connects to node index 1
// Explanation: There is a cycle in the linked list, where tail connects to the second node.

// Input: head = [1,2], pos = 0
// Output: tail connects to node index 0
// Explanation: There is a cycle in the linked list, where tail connects to the first node.

// Input: head = [1], pos = -1
// Output: no cycle
// Explanation: There is no cycle in the linked list.

public class LinkedListCycleII 
{
    public void Test()
    {
        var list1 = new List<ListNode>{
            new ListNode(1),
            new ListNode(2),
            new ListNode(2),
            new ListNode(3),
            new ListNode(3),
            new ListNode(4),
            new ListNode(4)
        };
        var list = new List<ListNode>{
            new ListNode(-1),
            new ListNode(-7),
            new ListNode(7),
            new ListNode(-4),
            new ListNode(19),
            new ListNode(6),
            new ListNode(-9),
            new ListNode(-5),
            new ListNode(-2),
            new ListNode(-5)
        };

        var head1 = list[0];
        head1.next = list[1];
        head1.next.next = list[2];
        head1.next.next.next = list[3];
        head1.next.next.next.next = list[4];
        head1.next.next.next.next.next = list[5];
        head1.next.next.next.next.next!.next = list[6];
        head1.next.next.next.next.next!.next!.next = list[7];
        head1.next.next.next.next.next!.next!.next!.next = list[8];
        head1.next.next.next.next.next!.next!.next!.next!.next = list[6];

        // var head2 = list[0];
        // head2.next = list[1];
        // var head3 = list[0];

        this.DetectCycle(head1)?.PrintAll(3);

        // this.DetectCycle(head2)?.Print();
        // this.DetectCycle(head3)?.Print();
    }

    public ListNode? DetectCycle(ListNode head) 
    {
        ListNode? temp = head;
        HashSet<ListNode> set = new HashSet<ListNode>();
        while (temp != null)
        {
            if (!set.Contains(temp))
                set.Add(temp);
            else
                return temp;
            temp = temp.next;
        }
        return null;
    }

    public bool DetectCyclePresent(ListNode head) 
    {
        if(head?.next == null) return false;
        var fast = new ListNode(head.val, head.next);
        var slow = new ListNode(head.val, head.next);

        while(true) {
            slow = slow.next;
            if(fast.next != null) {
                fast = fast.next.next;
            }
            else {
                return false;
            }

            if(slow == null || fast == null) {
                return false;
            }

            if(slow == fast){
                return true;
            }
        }
    }
}