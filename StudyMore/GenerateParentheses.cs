namespace algorithms.LeetCode;
using algorithms.Extensions;
// Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

//Input: n = 3
//Output: ["((()))","(()())","(())()","()(())","()()()"]

//Input: n = 1
//Output: ["()"]


public class GenerateParentheses 
{
    private char open = '(';
    private char close = ')';


    public void Test()
    {
        //this.Generate(1).Dump();
        this.Generate(4).Dump();
    }
    //1 <= n <= 8
    public IList<string> Generate(int n) 
    {
        var solutions = new List<string>(n);
        var tried = new HashSet<string>();
       
        while(true)
        {
            var solution = this.Generate(n, this.open, tried, string.Empty);
            if(solution.IsNullOrEmpty())
            {
               break;
            }

            solutions.Add(solution);
        }

        return solutions;

    }

    private string Generate(int n, char parenthesis, HashSet<string> tried, string singleSolution)
    {
        if(!this.IsValid(singleSolution, n) && singleSolution.Length != n*2)
        {
            //singleSolution += parentheses;
            var newString = singleSolution + parenthesis;
            bool canContinueWithCurrent = this.CanContinueSearch(newString, n, parenthesis, tried);
            if(canContinueWithCurrent)
            {   
                singleSolution = Generate(n, parenthesis, tried, newString);
            }
            else if(this.CanContinueSearch(singleSolution + this.Opposite(parenthesis), n, this.Opposite(parenthesis), tried)) //if(this.CanContinueSearch(newString, n, this.Opposite(parenthesis), solutions))
            {
                singleSolution = Generate(n, this.Opposite(parenthesis), tried, singleSolution + this.Opposite(parenthesis));
            }        
            else 
             {
                tried.Add(singleSolution);
                var stepBack = singleSolution.Substring(0, singleSolution.Length - 1);
                if(stepBack.IsNullOrEmpty()) return stepBack;
                singleSolution = Generate(n, this.Opposite(parenthesis), tried, stepBack);
             }   
        }
        tried.Add(singleSolution);
        return singleSolution;
    }

    private bool IsValid(string s, int n)
    {
        if(string.IsNullOrEmpty(s)) return false;
        if(s.Length < n*2) return false;
        int balance = 0;
        foreach(var ch in s)
        {
            if(ch == this.open) balance++;
            if(ch == this.close) balance--;
        }
        return balance is 0;
    }

    private bool CanContinueSearch(string s, int n, char parenthesis, HashSet<string> tried)
    {
        if(string.IsNullOrEmpty(s)) return true;
        if(tried.TryGetValue(s, out _)) return false;
        if(s.Count(x => x == parenthesis) > n) return false;
        if(s.Count(x => x == this.close) > s.Count(x => x == this.open)) return false;

        return true;
    }

    private char Opposite(char parenthesis)
    {
        if(parenthesis == this.open) return this.close;
        return this.open;
    }

}
// class Solution {
//     public List<String> generateParenthesis(int n) {
//         List<String> ans = new ArrayList();
//         backtrack(ans, new StringBuilder(), 0, 0, n);
//         return ans;
//     }

//     public void backtrack(List<String> ans, StringBuilder cur, int open, int close, int max){
//         if (cur.length() == max * 2) {
//             ans.add(cur.toString());
//             return;
//         }

//         if (open < max) {
//             cur.append("(");
//             backtrack(ans, cur, open+1, close, max);
//             cur.deleteCharAt(cur.length() - 1);
//         }
//         if (close < open) {
//             cur.append(")");
//             backtrack(ans, cur, open, close+1, max);
//             cur.deleteCharAt(cur.length() - 1);
//         }
//     }


// Approach 3: Closure Number
// Intuition

// To enumerate something, generally we would like to express it as a sum of disjoint subsets that are easier to count.

// Consider the closure number of a valid parentheses sequence S: the least index >= 0 so that S[0], S[1], ..., S[2*index+1] is valid. Clearly, every parentheses sequence has a unique closure number. We can try to enumerate them individually.

// Algorithm

// For each closure number c, we know the starting and ending brackets must be at index 0 and 2*c + 1. Then, the 2*c elements between must be a valid sequence, plus the rest of the elements must be a valid sequence.

// class Solution {
//     public List<String> generateParenthesis(int n) {
//         List<String> ans = new ArrayList();
//         if (n == 0) {
//             ans.add("");
//         } else {
//             for (int c = 0; c < n; ++c)
//                 for (String left: generateParenthesis(c))
//                     for (String right: generateParenthesis(n-1-c))
//                         ans.add("(" + left + ")" + right);
//         }
//         return ans;
//     }



// public IList<string> GenerateParenthesis(int n)
//         {
//             //Call the recurse function
//             BuildParenthesis(new StringBuilder(), n, n);

//             return result;
//         }

//         public void BuildParenthesis(StringBuilder para, int leftPara, int rightPara)
//         {
//             if (rightPara == 0)
//             {
//                 //Step4: Add the string to the result list.
//                 result.Add(para.ToString());
//             }    
//             //Step5: We want this tail function to end once it's added to the string list.
//             //We add this else function so that the function ends now that there are no left or right parenthesis left. 
//             //Now we must traverse back up through our functions.
//             else
//             {
//                 //Step1: If left bracket and right bracket equal each other, we want to start with the left bracket.
//                 if (leftPara == rightPara)
//                 {
//                     //Step2: Keep getting all the left parenthesis.
//                     para.Append("(");
//                     BuildParenthesis(para, leftPara - 1, rightPara);
//                     //Step8: Remove to start a new set combination
//                     para.Remove(para.Length - 1, 1);
//                 }
//                 //If they don't equal, then we need to distribute them evenly.
//                 else
//                 {
//                     if (leftPara > 0)
//                     {
//                         //Step2: We are still in Step 2 getting all the left parenthesis.
//                         para.Append("(");
//                         BuildParenthesis(para, leftPara - 1, rightPara);
//                         //Step7: We remove the last left parenthesis we added to continue the function.
//                         para.Remove(para.Length - 1, 1);
//                     }
//                     if (rightPara > 0)
//                     {
//                         //Step3: We got all of our left parenthesis, so now we need to get all of the right parenthesis.
//                         para.Append(")");
//                         BuildParenthesis(para, leftPara, rightPara-1);
//                         //Step6: We remove the last one added so the function 1 level up can figure out what to do.
//                         para.Remove(para.Length - 1, 1);
//                     }
//                 }
//             }

//         }