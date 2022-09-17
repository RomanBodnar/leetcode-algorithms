namespace algorithms.LeetCode;

public class ListNode 
    {
        public int val;
        public ListNode? next;
        public ListNode(int val = 0, ListNode? next = null) 
        {
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

      public void PrintAll(int count)
      {
        var a = new ListNode(this.val, this.next);
        do{
            Console.Write($"val: {a.val}");
            if(a.next is not null) Console.Write("\t");
            a = a.next;
            count--;
        }while(a is not null && count > 0);
        Console.WriteLine();
      }
    }