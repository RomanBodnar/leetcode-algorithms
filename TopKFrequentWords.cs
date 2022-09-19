namespace algorithms.LeetCode;

public class TopKFrequentWords {

    public void Test()
    {
        this.TopKFrequent(new string[]{"i","love","leetcode","i","love","coding"}, 3).Dump();
    }
    public IList<string> TopKFrequent(string[] words, int k) {
        var queue = new PriorityQueue<string, int>(new IntMaxComparer());
        var dictionary = new Dictionary<string, int>();
        foreach(var word in words)
        {
            if(!dictionary.ContainsKey(word))
            {
                dictionary[word] = 0;
            }
            dictionary[word]++;
        }
        dictionary.Dump();
        var mostFrequent = dictionary.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Take(k).Select(x => x.Key).ToList();

        return mostFrequent;
    }

    private class IntMaxComparer : IComparer<int>
    {
        public int Compare(int x, int y) => y.CompareTo(x);
    }
}