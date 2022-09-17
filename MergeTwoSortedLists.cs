namespace algorithms.LeetCode;

//You are given the heads of two sorted linked lists list1 and list2.
//Merge the two lists in a one sorted list. The list should be made by splicing together the nodes of the first two lists.
//Return the head of the merged linked list.
// Input: list1 = [1,2,4], list2 = [1,3,4]
// Output: [1,1,2,3,4,4]

// Input: list1 = [], list2 = [0]
// Output: [0]

//Both list1 and list2 are sorted in non-decreasing order.
public class MergeTwoSortedLists {
    public void Test()
    {
        var list1 = new ListNode(1, new ListNode(2, new ListNode(4)));
        var list2 = new ListNode(1, new ListNode(3, new ListNode(4)));
        MergeTwoLists(list1, list2).PrintAll();
        var list3 = (ListNode?)null;
        var list4 = new ListNode(0);
        MergeTwoLists(list3, list4).PrintAll();
    }
    public ListNode MergeTwoLists(ListNode? list1, ListNode? list2) {
        if(list1 == null) return list2!;
        if(list2 == null) return list1;
        ListNode head;

        if(list1.val <= list2.val)
        {
            head = new ListNode(list1.val);
            head.next = MergeTwoLists(list1.next, list2);
        }
        else
        {
            head = new ListNode(list2.val);
            head.next = MergeTwoLists(list2.next, list1);
        }
        return head;
    }
}