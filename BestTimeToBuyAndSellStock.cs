namespace algorithms.LeetCode;

// You are given an array prices where prices[i] is the price of a given stock on the ith day.
// You want to maximize your profit by choosing a single day to buy one 
// stock and choosing a different day in the future to sell that stock.
// Return the maximum profit you can achieve from this transaction. 
// If you cannot achieve any profit, return 0.
public class BestTimeToBuyAndSellStock {

    public void Test()
    {
        int[] unsorted = new int [] {2,1,2,0,1};
        int[] sortedDesc = new int [] {2,1};
        Console.WriteLine(this.MaxProfit(unsorted));
        Console.WriteLine(this.MaxProfit(sortedDesc));
    }

    public int MaxProfit(int[] prices) {
        if(prices.Length <= 1) return 0;
        
        int minPastIndex = 0;
        int maxFutureIndex = 1;
        bool minDecreased = false;

        var diffs = new HashSet<int>();
        for(int i = 1; i < prices.Length; i++)
        {
            if (prices[minPastIndex] > prices[i-1]) 
            { 
                minPastIndex = i - 1;
                minDecreased = true;
            }
            if(prices[maxFutureIndex] < prices[i] || minDecreased)
            {
                maxFutureIndex = i;
                minDecreased = false;
            }
            diffs.Add(prices[maxFutureIndex] - prices[minPastIndex]);
        }

        Console.WriteLine("min " + minPastIndex);
        Console.WriteLine("max " + maxFutureIndex);
        
        return Math.Max(diffs.Max(), 0);
    }

    public int MaxProfit2(int[] prices) {
       int maxProfit=0;
        int minPrice = int.MaxValue;
        
        for(int i=0; i<prices.Length; i++)
        {
            //if current price is lower, buy on this price
            
            if(prices[i]<minPrice)
            {
                minPrice=prices[i];
            }
            else{
                //if current price is not lower
                //try selling on this day to get max profit
                maxProfit = Math.Max(maxProfit,prices[i]-minPrice);
            }
            
        }
        
        return maxProfit;
    }
}