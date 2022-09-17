namespace algorithms.LeetCode;

public class LongestPossiblePalindrome {

    public void Test()
    {
        Console.WriteLine(this.LongestPalindrome("aaabbb"));
        Console.WriteLine(this.LongestPalindrome("bb"));
        Console.WriteLine(this.LongestPalindrome("ccc"));
         Console.WriteLine(this.LongestPalindrome("ccc"));
    }

    public int LongestPalindrome(string s) {
        if(s.Length == 1) return 1;
        var set = new Dictionary<char, int>();
        foreach(var ch in s)
        {
            if(set.ContainsKey(ch))
            {
                set[ch] += 1;
            }
            else
            {
                set[ch] = 1;
            }
        }
        var values = set.Select(kv => kv.Value).ToList();
        var sumEven = values.Where(x => x % 2 == 0).Sum();
        var odds = values.Where(x => x % 2 == 1).ToList();
        var sumOdd  = odds.Any() ? odds.Sum(x => x - 1) + 1 : 0;
        
        return sumEven + sumOdd;
    }
}