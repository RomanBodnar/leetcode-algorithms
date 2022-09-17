namespace algorithms.LeetCode;

//Given two strings s and t, return true if s is a subsequence of t, or false otherwise.
// A subsequence of a string is a new string that is formed from the original string 
//by deleting some (can be none) of the characters without disturbing the relative positions of the remaining characters. 
//(i.e., "ace" is a subsequence of "abcde" while "aec" is not).
// Input: s = "abc", t = "ahbgdc"
// Output: true
// Input: s = "axc", t = "ahbgdc"
// Output: false


public class IsSubsequenceDynamic 
{
    public void Test()
    {
        var a = (s: "abc", t: "ahbgdc");
        var b = (s: "axc", t: "ahbgdc");
        var c = (s: "aaaaaa", t: "bbaaaa");
        Console.WriteLine(this.IsSubsequence(a.s, a.t));
        Console.WriteLine(this.IsSubsequence(b.s, b.t));
         Console.WriteLine(this.IsSubsequence(c.s, c.t));
    }

    public bool IsSubsequence(string s, string t) {
        if(s.Length == 0 || t.Length == 0) return false;

        var index = 0;
        int elementsFound = 0;
        foreach(var ch in s)
        {
            while(index < t.Length)
            {
                if(ch == t[index])
                {
                    elementsFound++;
                    index++;
                    if(s.StartsWith(ch) && t.Length - elementsFound + 1 < s.Length) return false;
                    break;
                }
                index++;
            }
        }

        return elementsFound == s.Length;
    }
}