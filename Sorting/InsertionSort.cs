namespace algorithms;

public class InsertionSort 
{
    public static IEnumerable<int> Sort(int[] array)
    {
        if(array.IsNullOrEmpty() || array.IsSingle()) return array;

        for(int i = 1; i < array.Length; i++)
        {
            var key = array[i];
            int j = i - 1;
            while(j >= 0 && array[j] > key)
            {
                array[j+1] = array[j];
                j = j - 1;
            }
            array[j + 1] = key;
        }
        return array;
    }

    public static IEnumerable<int> SortDesc(int[] array)
    {
        if(array.IsNullOrEmpty() || array.IsSingle()) return array;

        for(int i = 1; i < array.Length; i++)
        {
            var key = array[i];
            int j = i - 1;
            while(j >= 0 && array[j] < key)
            {
                array[j+1] = array[j];
                j = j - 1;
            }
            array[j + 1] = key;
        }
        return array;
    }
}