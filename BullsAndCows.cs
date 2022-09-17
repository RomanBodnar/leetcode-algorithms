namespace algorithms.LeetCode;

// You are playing the Bulls and Cows game with your friend.

// You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:

// The number of "bulls", which are digits in the guess that are in the correct position.
// The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
// Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.

// The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.

// Input: secret = "1807", guess = "7810"
// Output: "1A3B"
// Explanation: Bulls are connected with a '|' and cows are underlined:
// "1807"
//   |
// "7810"

public class BullsAndCows {

    public void Test()
    {
        this.GetHint("1123", "0111").Dump();
    }
    public string GetHint(string secret, string guess) {
        int bulls = 0;
        int cows = 0;

        var dict = new Dictionary<char, int>();
        var unmatched = new List<char>();
        for(int i = 0; i < secret.Length; i++)
        {
            if(secret[i] == guess[i])
            {
                bulls++;
                continue;
            }
            unmatched.Add(secret[i]);
            if(!dict.ContainsKey(guess[i]))
            {
                dict[guess[i]] = 1;
            }
            else{
                dict[guess[i]]++;
            }
        }
        
        for (int i = 0; i < unmatched.Count; i++)
        {
            if(dict.ContainsKey(unmatched[i]))
            {
                cows++;
                dict[unmatched[i]]--;
                if(dict[unmatched[i]] == 0)
                {
                    dict.Remove(unmatched[i]);
                }
            }
        }

        return $"{bulls}A{cows}B";
    }
}