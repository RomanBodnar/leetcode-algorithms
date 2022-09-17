namespace algorithms.LeetCode;

// Given two strings s and p, return an array of all the start indices of p's anagrams in s. 
// You may return the answer in any order.
// An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, 
// typically using all the original letters exactly once.

public class FindAllAnagramsInString {
    private Dictionary<char, int> frequencyMap = new();
    
    public void Test()
    {
        this.FindAnagrams("abca", "abc").Dump();
        this.FindAnagrams("abab", "ab").Dump();
        this.FindAnagrams("abcacb", "abc").Dump();
    }

    public IList<int> FindAnagrams(string s, string p) {
        if (s.Length < p.Length)
            return new List<int>{};
        Dictionary<char, int> freq = new Dictionary<char, int>();
        foreach (char ch in p)
            if (freq.ContainsKey(ch))
                freq[ch]++;
            else
                freq[ch] = 1;
        
        int start = 0, matched = 0;
        List<int> result = new List<int>();
        for (int end = 0; end < s.Length; end++) 
        {
            char right = s[end];
            if (freq.ContainsKey(right)) 
            {
                freq[right]--;
                if (freq[right] == 0)
                    matched += 1;
            }
            while (matched == freq.Count) 
            {
                if (end - start + 1 == p.Length) 
                    result.Add(start);
                char left = s[start];
                if (freq.ContainsKey(left))
                {
                    freq[left]++;
                    if (freq[left] > 0)
                        matched -= 1;
                }
                start++;
            }
            
        }
        return result;
    }

    private bool IsAnagram(char[] substring)
    {
        var newFrequencyMap = new Dictionary<char, int>();
        foreach (var c in substring)
        {
            if (!newFrequencyMap.ContainsKey(c))
            {
                newFrequencyMap.Add(c, 0);
            }
            newFrequencyMap[c]++;
        }
        foreach(var kv in frequencyMap)
        {
            if(!newFrequencyMap.ContainsKey(kv.Key)) return false;
            if(frequencyMap[kv.Key] != newFrequencyMap[kv.Key]) return false;
        }
        return true;
    }
}