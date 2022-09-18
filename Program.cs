namespace algorithms;

using algorithms.Extensions;
using algorithms.LeetCode;
internal class Program
{
    // h:1 2 s:3 4 f:5
    // 4 5 1 2 3

    // h:s:1 f:2 
    // first.next = head
    // 1 2 1 ...
    // head = second.next
    //  h:,s.n:,f:2 f.n:1 ...
    // second.next = null
    // 
    static void Main(string[] args)
    {
       new StringDecode().Test();
    }

    public static ListNode RotateRight(ListNode head, int k) {
        if(head?.next is null) return head;
        var n = 1;
        var first = new ListNode(head.val, head.next);
        var second = new ListNode(head.val, head.next);

        while(first.next is not null)
        {
            first = first.next;
            n++;
        }
        int i = n > k ? n - k - 1 : n - (n%2);
        //int i = n - k - 1 > 0 ? n - k - 1 : n + (n - k );
        Console.WriteLine($"n = {n}  i = {i}");

        //return head;
        
        if(i > 0)
        {
            while(i > 0)
            {   
                second = second.next ?? head;
                i--;
            }
        }
        else
        {
            first.next = head;

        }
         Console.WriteLine($"first");
         first.PrintAll();
          Console.WriteLine($"second");
          second.PrintAll();
        first.next = head;
        head = second.next;
        second.next = null;
        return head;
    }
    
 // Definition for singly-linked list.
  public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int val=0, ListNode next=null) {
          this.val = val;
          this.next = next;
      }

      public void Print()
      {
        Console.WriteLine($"val: {this.val}");
      }

      public void PrintAll()
      {
        var a = new ListNode(this.val, this.next);
        do{
            Console.Write($"val: {a.val}");
            if(a.next is not null) Console.Write("\t");
            a = a.next;
        }while(a is not null);
        Console.WriteLine();
      }
  }
 
}

