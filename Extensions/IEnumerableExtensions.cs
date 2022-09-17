namespace algorithms;

public static class IEnumerableExtensions 
{
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
    {
        return list is null || !list.Any();
    }

    public static bool IsSingle<T>(this IEnumerable<T> list)
    {
        return list.Count() == 1;
    }

    public static void Print<T>(this IEnumerable<T> list)
    {
        var joined = string.Join(" ", list.Select(x => $"{x}"));
        Console.WriteLine(joined);
    }
}