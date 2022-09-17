namespace algorithms.LeetCode;

// You are given a string s and an integer k.
// You can choose any character of the string and change it to any other uppercase English character.
// You can perform this operation at most k times.
// Return the length of the longest substring containing the same letter you can get
// after performing the above operations.

// Input: s = "ABAB", k = 2
// Output: 4
// Explanation: Replace the two 'A's with two 'B's or vice versa.

// Input: s = "AABABBA", k = 1
// Output: 4
// Explanation: Replace the one 'A' in the middle with 'B' and form "AABBBBA".
// The substring "BBBB" has the longest repeating letters, which is 4.


public class LongestRepeatingCharacterReplacement {
    public int CharacterReplacement(string s, int k) {
        
        return -1;   
    }
}


// class Solution:
//     def characterReplacement(self, s: str, k: int) -> int: 
//         d={} #to calculate the frquency of elements present in the particular substring or sliding window
//         a=0 #for counting the length of the longest substring
//         l=0 #the left pointer (starts from the left index of the s)
//         for r in range(len(s)): # r is taken as the right pointer and it will go to the end of the substring or sliding window which will be chosen
//             #now calulating te frequency of the elements present in the particular chosen substring
//             if s[r] in d: 
//                 d[s[r]]+=1 
//             else: 
//                 d[s[r]]=1 
//             #now checking how many less fequency element present in d so that it can be replaced and converted to the max frequency element
//             # (r-l+1) indicates the total length of the sliding window chosen
//             #max(d.values() it takes the maximum frequency element so that after subtracting
//             #it from the length of the sliding window can give how many elements need to
//             #be converted into max frequency elements (it should be greater than k)
//             while (r-l+1)-max(d.values()) >k: 
//                 #if greater than k then the current window will move one step forward and 
//                 #the starting of the element of the window need to be decrement by 1
//                 #as its frequency will decrement once its gone from window
//                 d[s[l]]-=1
//                 l+=1 
//                 #moving forward the left pointer(shifting window forward) 
//             #a storing the length of longest substring
//             a=max(a,r-l+1) 
//         return a