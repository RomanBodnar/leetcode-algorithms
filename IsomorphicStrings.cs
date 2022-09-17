namespace algorithms.LeetCode;

public class IsomorphicStrings {

// Given two strings s and t, determine if they are isomorphic.
// Two strings s and t are isomorphic if the characters in s can be replaced to get t.
// All occurrences of a character must be replaced with another character while preserving the order of characters.
// No two characters may map to the same character, but a character may map to itself.
    public bool IsIsomorphic(string s, string t) {
        var distinctS = s.Distinct();
        var distinctT = t.Distinct();
        
        if(distinctS.Count() != distinctT.Count()) return false;
        var dict = new Dictionary<char, char>();
        for(int i = 0; i < s.Length; i++)
        {
            if(!dict.ContainsKey(s[i]))
            {
                dict[s[i]] = t[i];
                continue;
            }
            if(dict[s[i]] != t[i])
            {
                return false;
            }
        }
        return true;
    }
}