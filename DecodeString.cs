using System.Text;

namespace algorithms.LeetCode;

// Given an encoded string, return its decoded string.
// The encoding rule is: k[encoded_string], where the encoded_string inside the square brackets is being repeated exactly k times.
// Note that k is guaranteed to be a positive integer.
// You may assume that the input string is always valid; there are no extra white spaces,
// square brackets are well-formed, etc. Furthermore, you may assume that the original data does not contain
// any digits and that digits are only for those repeat numbers, k.
// For example, there will not be input like 3a or 2[4].    
// The test cases are generated so that the length of the output will never exceed 105.


// Input: s = "3[a]2[bc]"
// Output: "aaabcbc"
// RELATED TOPICS: STRING STACK RECURSION
public class StringDecode {

    public void Test(){
         this.DecodeString("2[abc]3[cd]zerg").Dump();
           this.DecodeString("2s3[sd]").Dump();
         this.DecodeString("yyy2[eb]jjj2[f]").Dump();
          this.DecodeString("3[a2[c]]").Dump();
    }

    int i = 0;
    public string DecodeString(string s) {
        var result = new StringBuilder();
        var localStack = new Stack<string>();
        string substring = "";
        for(i = s.Length - 1; i >=0; )
        {
            if(s[i] != '[' && s[i] != ']')
            {
                localStack.Push(s[i].ToString());
                i--;
                continue;
            }
            if(s[i] == ']')
            {
                var a = this.DecodeString(s.Substring(0, i));
                localStack.Push(a);
            }
            if(i >= 0 && s[i] == '[')
            {
                i--; // move to number
                
                int numberOfDigits = 0;
                int repeat = 0;
                while(i >= 0 && s[i] >= '0' && s[i] <= '9')
                {
                    numberOfDigits++;
                    repeat += (int)Char.GetNumericValue(s[i]) * (int)Math.Pow(10, numberOfDigits - 1);        
                    i--;
                }
                var stackString = "";
                while(localStack.TryPop(out string str))
                {
                    stackString += str;
                }
                while(repeat > 0)
                {
                    result.Append(stackString);
                    repeat--;
                } 
                substring = result.ToString();
                return substring;
            }
        }
        result.Clear();
        while(localStack.TryPop(out string str))
        {
            result.Append(str);
        }
        return result.ToString();
    }
}